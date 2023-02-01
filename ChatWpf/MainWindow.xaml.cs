using GazoFicationAndWaterWeb.Data;
using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAutorization_Click(object sender, RoutedEventArgs e)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Members>("GazWater");
            var list = collection.Find(x => true).ToList();

            if (LoginBox.Text != "" && PasswordBox.Text != "")
            {
                foreach (var item in list)
                {
                    if (LoginBox.Text == item.Login && PasswordBox.Text == item.Password)
                    {
                        ChatWindow chatWindow = new ChatWindow();
                        chatWindow.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
    }
}
