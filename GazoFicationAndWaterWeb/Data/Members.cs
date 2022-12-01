using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GazoFicationAndWaterWeb.Data
{
    [BsonKnownTypes(typeof(Customer), typeof(Developer), typeof(Designer))]
    public class Members
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        [BsonIgnoreIfDefault]
        public string Login { get; set; }
        [BsonIgnoreIfDefault]
        public string Password { get; set; }
        [BsonIgnoreIfDefault]
        public string Email { get; set; }
        [BsonIgnoreIfDefault]
        public string Phone { get; set; }
    }
}
