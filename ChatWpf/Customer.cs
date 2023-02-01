using MongoDB.Bson.Serialization.Attributes;

namespace GazoFicationAndWaterWeb.Data
{
    public class Customer : Members
    {
        [BsonIgnoreIfNull]
        public string FullName { get; set; }
        [BsonIgnoreIfNull]
        public string Department { get; set; }
    }
}
