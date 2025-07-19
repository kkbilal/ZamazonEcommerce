using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using Zamazon.Discount.Entities;

namespace Zamazon.Discount.Context
{
    public class DapperContext: DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder )
        {
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-82RLRPM\\SQLEXPRESS;Initial Catalog=ZamazonDiscountDb;integrated Security=true;TrustServerCertificate=True");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
