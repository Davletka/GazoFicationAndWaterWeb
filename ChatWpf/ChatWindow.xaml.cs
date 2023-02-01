using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Bson;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using GazoFicationAndWaterWeb.Data;

namespace ChatWpf
{
    /// <summary>
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        HubConnection connection;
        public Members members;
        public ChatWindow()
        {
            InitializeComponent();

                    connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7055/chat")
            .WithAutomaticReconnect()
            .Build();


            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    ChatPanel.Items.Insert(0, newMessage);
                });
            });

            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Members>("GazWater");
            var list = collection.Find(x => true).ToList();

            foreach(var item in list)
            {
                UsersList.Items.Add(item.Login);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // подключемся к хабу
                await connection.StartAsync();
                ChatPanel.Items.Add("Вы вошли в чат");
                BtnSend.IsEnabled = true;
            }
            catch (Exception ex)
            {
                ChatPanel.Items.Add(ex.Message);
            }
        }

        private async void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // отправка сообщения
                await connection.InvokeAsync("SendMessage", LoginLabel.Content, MessageBox.Text);
            }
            catch (Exception ex)
            {
                ChatPanel.Items.Add(ex.Message);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await connection.InvokeAsync("Send", "", $"Пользователь {LoginLabel.Content} выходит из чата");
            await connection.StopAsync();   // отключение от хаба
        }
    }
}
