using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FistAPI.Models;
using FistAPI.Context;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver;


namespace FistAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChucVuController : Controller
    {
        MongoClientSettings settings = new MongoClientSettings();
        MongoServerAddress address = new MongoServerAddress("localhost", 27017);
        MongoClient client;
        private string DBName = "QLNHANVIEN";

        public ChucVuController()
        {
            settings.Server = address;
            client = new MongoClient();
        }


        [HttpGet(Name = "GetAllCV")]
        public IEnumerable<ChucVu> GetAll()
        {
            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<ChucVu>("CHUC_VU");
            var qr = collection.AsQueryable<ChucVu>().ToList();
            return qr;
        }


        [HttpGet("{ma}", Name ="GetChucVu")]
        public IActionResult GetById(string ma)
        {
            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<ChucVu>("CHUC_VU");
            var query = collection.AsQueryable<ChucVu>().ToList();
            var result = query.FirstOrDefault(c => c.MA_CV == ma);
            return new ObjectResult(result);
        }


        [HttpPost]
        public IActionResult Create([FromBody]ChucVu item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<ChucVu>("CHUC_VU");

            collection.InsertOne(item);

            return new ObjectResult(item);
        }


        [HttpPut]
        public IActionResult Update([FromBody]ChucVu item)
        {
            if (item == null || item.MA_CV != item.MA_CV)
            {
                return BadRequest();
            }

            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<ChucVu>("CHUC_VU");
            var query = collection.AsQueryable<ChucVu>().ToList();
            var result = query.FirstOrDefault(c => c.MA_CV == item.MA_CV);
            if (result == null)
            {
                return NotFound();
            }

            var filter = Builders<ChucVu>.Filter.Eq("MA_CV", item.MA_CV);
            var update = Builders<ChucVu>.Update.Set(s => s.TEN_CV, item.TEN_CV).Set(s => s.LUONG_CV, item.LUONG_CV);

            collection.UpdateOne(filter, update);

            return CreatedAtRoute("GetChucVu", new { ma = item.MA_CV }, item);
        }


        [HttpDelete("{ma}")]
        public IActionResult Delete(string ma)
        {
            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<ChucVu>("CHUC_VU");
            var filter = Builders<ChucVu>.Filter.Eq("MA_CV", ma);
            collection.DeleteOne(filter);
            var query = collection.AsQueryable<ChucVu>().ToList();
            return CreatedAtRoute("GetAllCV",query);
        }
    }
}
