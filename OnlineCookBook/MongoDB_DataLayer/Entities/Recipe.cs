using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;

namespace OnlineCookBook.MongoDB_DataLayer.Entities
{
    public class Recipe
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Ptime { get; set; }

        public string Longd { get; set; }

        public string Shortd { get; set; }

        public string Status { get; set; }

        public string Image { get; set; }

        public MongoDBRef User { get; set; }

        public List<MongoDBRef> Ingredients { get; set; }

        public Recipe()
        {
            Ingredients = new List<MongoDBRef>();
        }
    }
}