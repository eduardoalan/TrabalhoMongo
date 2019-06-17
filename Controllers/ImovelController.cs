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
    public class ImovelController : Controller
    {
        private readonly MongoDBContext _mongoDBContext =
            new MongoDBContext();
        public IActionResult Index()
        {
            return View(_mongoDBContext.Imovels.Find(s => true)
                .ToList());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Imovels.InsertOne(imovel);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            //View(_mongoDBContext.Servidores.Find(s => s.Id == ObjectId.Parse(Id)));
            var imovelDel = _mongoDBContext.Imovels
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(imovelDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string Id)
        {
            var imovelDel = _mongoDBContext.Imovels
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Id)
        {
            var serv = _mongoDBContext.Imovels.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(serv);
        }

        [HttpPost]
        public ActionResult Edit(Imovel imovel, string id)
        {
            if (ModelState.IsValid)
            {
                imovel.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", ObjectId.Parse(id));
                //var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
                _mongoDBContext.Imovels.ReplaceOne(filter, imovel);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}