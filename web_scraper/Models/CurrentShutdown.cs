using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace web_scraper.Models
{
    public class CurrentShutdown
    {
        [BsonId]
        public string Id { get; set; }
        public string Region { get; set; }

        public string Street { get; set; }
        public string Disconnectdate { get; set; }
        public string Disconnecthour { get; set; }
        public string Connectdate { get; set; }
        public string Connecthour { get; set; }
       
        
    }   
}