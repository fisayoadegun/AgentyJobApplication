using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyJobApplication.Models
{
	public class MyResume
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public List<string> skills { get; set; }
        public string experience { get; set; }
    }
}
