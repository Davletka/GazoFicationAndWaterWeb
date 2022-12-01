using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace GazoFicationAndWaterWeb.Data
{
    public class MongoDataBase
    {
        public static void AddDb(Members member)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Members>("GazWater");
            collection.InsertOne(member);
        }

        public static List<Members> FindAll()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Members>("GazWater");
            var list = collection.Find(x => true).ToList();
            return list;
        }

        public static void ReplaceByName(Members member, string login)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Members>("GazWater");
            collection.ReplaceOne(x => x.Login == member.Login, member);
        }

        public static void AddDbProjects(Projects projects)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Projects>("Projects");
            collection.InsertOne(projects);
        }

        public static void UploadToDb(IBrowserFile browserFile, string path)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Davletka");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                gridFS.UploadFromStream(browserFile.Name, fs);
            }
        }

        public static void DownloadToLocal(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Davletka");
            var gridFS = new GridFSBucket(database);
            using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/DownloadFiles/")}{name}", FileMode.CreateNew))
            {
                gridFS.DownloadToStreamByName($"{name}", fs);
            }
        }

        public static void AddDbDocuments(Documents document)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("Davletka");
            var collection = database.GetCollection<Documents>("Documents");
            collection.InsertOne(document);
        }
    }
}
