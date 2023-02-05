using RoyalWeb.Models;
using Microsoft.EntityFrameworkCore;



namespace RoyalWeb.Data
{

    public class RoyalContext : DbContext
    {
        public RoyalContext(DbContextOptions<RoyalContext> options) : base(options) { }

        public DbSet<House> Houses { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<DailyEvent> DailyEvents { get; set; }
        public DbSet<WeeklyEvent> WeeklyEvents { get; set; }
        public DbSet<YearlyEvent> YearlyEvents { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Palace> Palaces { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=RoyalWeb2; Trusted_Connection=true; TrustServerCertificate=true");
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().ToTable("House");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Opinion>().ToTable("Opinion");
            modelBuilder.Entity<Court>().ToTable("Court");
            modelBuilder.Entity<Title>().ToTable("Title");
            modelBuilder.Entity<DailyEvent>().ToTable("DailyEvent");
            modelBuilder.Entity<WeeklyEvent>().ToTable("WeeklyEvent");
            modelBuilder.Entity<YearlyEvent>().ToTable("YearlyEvent");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Palace>().ToTable("Palace");
            modelBuilder.Entity<Holding>().ToTable("Holding");
        }
    }
}
