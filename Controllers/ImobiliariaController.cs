using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoTrabalhoo.Models;

namespace MongoTrabalhoo.Controllers
{
    public class ImobiliariaController : Controller
    {
        private readonly MongoDBContext _mongoDBContext =
            new MongoDBContext();
        public IActionResult Index()
        {
            return View(_mongoDBContext.Imobiliarias.Find(s => true)
                .ToList());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Imobiliaria imobiliaria)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Imobiliarias.InsertOne(imobiliaria);
                return RedirectToAction("Index");
            }
            ViewBag.categorias =
                _mongoDBContext.Imobiliarias.Find(s => true).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(String Id)
        {
      
            var servidorDel = _mongoDBContext.Imobiliarias
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            ViewBag.imobiliarias =
               _mongoDBContext.Imobiliarias.Find(s => true).ToList();
            return View(servidorDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(String Id)
        {
            var servidorDel = _mongoDBContext.Imobiliarias
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(String Id)
        {
            var serv = _mongoDBContext.Imobiliarias.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(serv);
        }

        [HttpPost]
        public ActionResult Edit(Imobiliaria imobiliaria, String Id)
        {
            if (ModelState.IsValid)
            {
                imobiliaria.Id = ObjectId.Parse(Id);
                var filter = new BsonDocument("_id", ObjectId.Parse(Id));
                //var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
                _mongoDBContext.Imobiliarias.ReplaceOne(filter, imobiliaria);

                return RedirectToAction("Index");
            }
            return View();
        }


    }
}