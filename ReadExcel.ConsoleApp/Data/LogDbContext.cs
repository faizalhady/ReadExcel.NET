using Microsoft.EntityFrameworkCore;


public class LogDbContext : DbContext
{
    public DbSet<LogData> LogData { get; set; }  // The DbSet for the logs

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace with your actual SQL Server connection string
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-GV8LAF4;Database=LogDb;Trusted_Connection=True;TrustServerCertificate=True;");

    }
}
