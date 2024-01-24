using Microsoft.EntityFrameworkCore;

namespace Cargo_Tracking_Application.Model
{
    public class CargoDB: DbContext 
    {
        public CargoDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<VesselData> Vessels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=M\\SQLEXPRESS;Initial Catalog=CargoTrackDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
