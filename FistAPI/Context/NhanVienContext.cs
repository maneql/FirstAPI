using Microsoft.EntityFrameworkCore;
using FistAPI.Models;

namespace FistAPI.Context
{
    public class NhanVienContext: DbContext
    {
        public NhanVienContext(DbContextOptions<NhanVienContext> options)
            : base(options)
        {
        }

        public DbSet<NhanVien> _NhanVien { get; set; }
    }
}
