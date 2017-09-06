using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FistAPI.Models;
using FistAPI.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace FistAPI.Controllers
{
    [Route("api/[controller]")]
    public class NhanVienController : Controller
    {

        MongoClientSettings settings = new MongoClientSettings();
        MongoServerAddress address = new MongoServerAddress("localhost", 27017);
        MongoClient client;
        private string DBName = "QLNHANVIEN";

        public NhanVienController()
        {
            settings.Server = address;
            client = new MongoClient();
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<NhanVien> GetAllNhanVien()
        {
            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<NhanVien>("NHAN_VIEN");
            var qr = collection.AsQueryable<NhanVien>().ToList();
            return qr;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetNhanVien")]
        public IActionResult GetNhanVienById(string id)
        {
            var db = client.GetDatabase(DBName);
            var collection = db.GetCollection<NhanVien>("NHAN_VIEN");
            var qr = collection.AsQueryable<NhanVien>().ToList();
            var item = qr.FirstOrDefault(t => t.MA_NV == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
