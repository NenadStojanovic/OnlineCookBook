using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using OnlineCookBook.MongoDB_DataLayer.Entities;


namespace OnlineCookBook.MongoDB_DataLayer
{
    public class DataLayer
    {
        public List<Recipe> dajMiSveAaaaaa(string cat)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");

         


           List<Recipe> r = collection.Find(f => f.Category == cat).ToList();
            return r;
          
        }

        public List<Recipe> ReturnRecipesByCategory(string category)//vraca recepte iz odredjene kategorije
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");

            List<Recipe> r = collection.Find(f => f.Category == category).ToList();
            return r;
        }


        public Recipe ReturnRecipeById(string id)//vraca recept po Id koji je zadat kao string
        {
            ObjectId id1 = ObjectId.Parse(id);
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");

            Recipe r = collection.Find(f => f.Id == id1).First();
            return r;
        }

        public Recipe ReturnRecipeByIdObjectId(ObjectId id)//vraca recept po Id koji je zadat kao ObjectId
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");

            Recipe r = collection.Find(f => f.Id == id).First();
            return r;
        }


        public List<Recipe> ReturnAllRecipes() //vraca sve recepte svih kategorija
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");




            List<Recipe> r = collection.Find(_ => true).ToList();
            return r;
        }



        public List<Recipe> ReturnRecipesByPartialName(string namePart)//vraca recept po delu naziva-za pretragu korisno
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");

            List<Recipe> r = ReturnAllRecipes();

            List<Recipe> partialR = new List<Recipe>();

            foreach(Recipe re in r)
            {
                string name = re.Name.ToLower();

                if(name.Contains(namePart.ToLower()))
                {
                    partialR.Add(re);
                }
            }

            return partialR;
            

        }
       


        public void InsertRecipeToDB(Recipe p)//dodaje recept u bazu
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");

            collection.InsertOne(p);
        }

        public void DeleteRecipeFromDB(ObjectId id)//brise recept iz baze po Id, a moze da se napravi po cemu god
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = new MongoClient(connectionString);
            var db = server.GetDatabase("probica");

            var collection = db.GetCollection<Recipe>("recipe");


            collection.DeleteOne(f => f.Id == id);
        }


        //recipe
        //vraca po tagovima****************************************************************************************************************
        //update funkciju za status********************************************************************************************************
        //vraca listu objekata tipa ingredient*********************************************************************************************

        //order
        //upisuje Order*********************************************************************************************************************
        //update Order po Id, menja status, ***********************************************************************************************
        //vraca Ordere za odredjenog Usera po Id*************************************************************************************************
        //vraca Ordere adminu ciji je status pending ***************************************************************************************


        //user
        //upisuje Usera u bazu***************************************************************************************************************
        //Vraca usera iz baze sa Id***********************************************************************************************************


        //comment
        //upisuje comment u bazu****************************************************************************************************************
        //vraca listu komentara za odredjeni Id recepta***************************************************************************************


        //ingredient ****************************************************************************************************************************
        //dodaje ingredient u bazu***************************************************************************************************************
    }
}