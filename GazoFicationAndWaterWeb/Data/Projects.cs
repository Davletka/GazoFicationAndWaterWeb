using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GazoFicationAndWaterWeb.Data
{
    public class Projects
    {
        [BsonId]
        ObjectId _id;
        [BsonIgnoreIfDefault]
        public string? Name { get; set; }
        [BsonIgnoreIfDefault]
        public string? CustomerName { get; set; }
        [BsonIgnoreIfDefault]
        public string? Theme { get; set; }
        [BsonIgnoreIfDefault]
        public Developer? developer { get; set; }
        [BsonIgnoreIfDefault]
        public Designer? designer { get; set; }

        public List<Documents> Documents { get; set; }
    }
}
