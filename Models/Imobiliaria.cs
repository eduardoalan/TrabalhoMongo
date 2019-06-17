using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MongoTrabalhoo.Models
{
    [BsonIgnoreExtraElements]
    public class Imobiliaria
    {
        public ObjectId Id { get; set; }
        [Required]
        public string nome { get; set; }
        
    }
}
