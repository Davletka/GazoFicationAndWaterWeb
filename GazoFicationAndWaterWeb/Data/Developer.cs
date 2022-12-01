using MongoDB.Bson.Serialization.Attributes;

namespace GazoFicationAndWaterWeb.Data
{
    public class Developer : Members
    {
        [BsonIgnoreIfNull]
        public string OGRN { get; set; }
        [BsonIgnoreIfNull]
        public string INN { get; set; }
        [BsonIgnoreIfNull]
        public string KPP { get; set; }
        [BsonIgnoreIfNull]
        public string Address { get; set; }
        [BsonIgnoreIfNull]
        public string HeadOfTheExecutiveDepartmentOfTheRTCommittee { get; set; }
    }
}
