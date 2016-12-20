using Microsoft.EntityFrameworkCore;
using Storm.InterviewTest.Hearthstone.Data.Domain;

namespace Storm.InterviewTest.Hearthstone.Data
{
    public class HearthstoneDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=../../../../../data/Hearthstone.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MinionCard>().HasBaseType<Card>();

            modelBuilder.Entity<HeroCard>().HasBaseType<MinionCard>();

            modelBuilder.Entity<SpellCard>().HasBaseType<Card>();

            modelBuilder.Entity<WeaponCard>().HasBaseType<Card>();
        }

        
    }
}