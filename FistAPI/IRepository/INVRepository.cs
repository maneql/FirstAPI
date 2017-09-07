using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FistAPI.Models;
using MongoDB.Driver;

namespace FistAPI.IRepository
{
    public interface INVRepository
    {
        Task<IEnumerable<NhanVien>> Get();
        Task<NhanVien> Get(string id);
        Task Add(NhanVien nhanvien);
        Task<string> Update(string id, NhanVien nhanVien);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
