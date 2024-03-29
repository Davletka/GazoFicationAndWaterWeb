﻿using MongoDB.Bson.Serialization.Attributes;

namespace GazoFicationAndWaterWeb.Data
{
    [BsonIgnoreExtraElements]
    public class Documents
    {
        public string? Customer { get; set; }
        public string? Login { get; set; }

        public string? FileName { get; set; }

        public bool isTrue { get; set; }
    }
}
