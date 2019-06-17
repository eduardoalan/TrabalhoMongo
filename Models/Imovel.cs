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
    public class Imovel
    {
        public ObjectId Id { get; set; }
        [Required]
        public string estado { get; set; }
        public string cidade { get; set; }
        public int rua { get; set; }
        public string cep { get; set; }
        public int id_imobiliaria { get; set; }
       
        }
}
