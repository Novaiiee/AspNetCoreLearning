using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreLearning.Models
{
    public class Book
    {
        public Guid Id { get; init; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}

