using MongoDB.Bson.Serialization.Attributes;

namespace GazoFicationAndWaterWeb.Data
{
    public class Designer : Members
    {
        [BsonIgnoreIfNull]
        public string? NameOfTheProjectOrganization;
        [BsonIgnoreIfNull]
        public string? OGRN;
        [BsonIgnoreIfNull]
        public string? IPP;
        [BsonIgnoreIfNull]
        public string? KPP;
        [BsonIgnoreIfNull]
        public string? Address;
        [BsonIgnoreIfNull]
        public string? Director;
        [BsonIgnoreIfNull]
        public string? MainInjenerProject;
    }
}
