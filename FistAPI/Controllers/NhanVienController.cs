using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FistAPI.Models;
using FistAPI.IRepository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Newtonsoft.Json;

namespace FistAPI.Controllers
{
    [Route("api/[controller]")]
    public class NhanVienController : Controller
    {
        private readonly INVRepository _NVRepository;

        public NhanVienController(INVRepository NVRepository)
        {
            _NVRepository = NVRepository;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return this.GetNV();
        }

        public async Task<string> GetNV()
        {
            var nhanviens = await _NVRepository.Get();
            return JsonConvert.SerializeObject(nhanviens);
        }

        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetNVById(id);
        }

        public async Task<string> GetNVById(string id)
        {
            var nhanvien = await _NVRepository.Get(id) ?? new NhanVien();
            return JsonConvert.SerializeObject(nhanvien);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] NhanVien nhanvien)
        {
            await _NVRepository.Add(nhanvien);
            return "";
        }

        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] NhanVien nhanvien)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id !!!";
            return await _NVRepository.Update(id,nhanvien);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id !!!";
            await _NVRepository.Remove(id);
            return "";
        }

    }
}
