using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class Context : DbContext
    {
        public DbSet<Good> Good { get; set; }
        public DbSet<Coin> Coin { get; set; }
        public DbSet<VMPurse> VMPurse { get; set; }
        public DbSet<UserPurse> UserPurse { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VendingMachineDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigurationVMPurse());
            modelBuilder.ApplyConfiguration(new ConfigurationUserPurse());

            modelBuilder.Entity<Good>().HasData(
                new Good { GoodID = 1, GoodName = "Чай", GoodPrice = 13, GoodCount = 13 },
                new Good { GoodID = 2, GoodName = "Кофе", GoodPrice = 18, GoodCount = 20 },
                new Good { GoodID = 3, GoodName = "Кофе с молоком", GoodPrice = 21, GoodCount = 20 },
                new Good { GoodID = 4, GoodName = "Сок", GoodPrice = 35, GoodCount = 15 }
                );

            modelBuilder.Entity<Coin>().HasData(
                new Coin { CoinID = 1, CoinFaceValue = 1 },
                new Coin { CoinID = 2, CoinFaceValue = 2 },
                new Coin { CoinID = 3, CoinFaceValue = 5 },
                new Coin { CoinID = 4, CoinFaceValue = 10 }
                );

            modelBuilder.Entity<VMPurse>().HasData(
                new VMPurse { CoinID = 1, Count = 100 },
                new VMPurse { CoinID = 2, Count = 100 },
                new VMPurse { CoinID = 3, Count = 100 },
                new VMPurse { CoinID = 4, Count = 100 }
                );

            modelBuilder.Entity<UserPurse>().HasData(
                new UserPurse { CoinID = 1, Count = 10 },
                new UserPurse { CoinID = 2, Count = 30 },
                new UserPurse { CoinID = 3, Count = 20 },
                new UserPurse { CoinID = 4, Count = 15 }
                );
        }
    }
}
