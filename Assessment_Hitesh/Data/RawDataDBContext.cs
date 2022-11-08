using Assessment_Hitesh.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment_Hitesh.Data;

public class RawDataDBContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public RawDataDBContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=dev;Initial Catalog=HRMS_Test;Integrated Security=True;TrustServerCertificate=True;");
    }
    public DbSet<RawData> rawdata { get; set; }
}