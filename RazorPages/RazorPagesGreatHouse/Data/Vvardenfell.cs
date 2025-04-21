using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GreatHouse.Model;

    public class Vvardenfell : DbContext
    {
        public Vvardenfell (DbContextOptions<Vvardenfell> options)
            : base(options)
        {
        }

        public DbSet<GreatHouse.Model.House> House { get; set; } = default!;
        public DbSet<GreatHouse.Model.Person> Person {get;set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasData
            (
                new House {Id = 1, Clan = GreatHouse.Model.Clan.Hlaalu, Slaver = false, Strength = 50000, Characteristic = "Greedy"},
                new House {Id = 2, Clan = GreatHouse.Model.Clan.Redoran, Slaver = false, Strength = 10000, Characteristic = "Traditionalist"}
            );
            modelBuilder.Entity<Person>().HasData
            (
                new Person { Id = 1, Name = "Umbacano", Race= GreatHouse.Model.Race.Altmer, Level = 10, Health = 50, HouseId = 1},
                new Person { Id = 2, Name = "Zainsubani", Race= GreatHouse.Model.Race.Dunmer, Level = 5, Health = 25, HouseId = 1},
                new Person { Id = 3, Name = "Smelrik", Race= GreatHouse.Model.Race.Orsimer, Level = 30, Health = 200, HouseId = 2},
                new Person { Id = 4, Name = "Sotha", Race= GreatHouse.Model.Race.Dunmer, Level = 50, Health = 200, HouseId = 2},
                new Person { Id = 5, Name = "Gamer", Race= GreatHouse.Model.Race.Nord, Level = 4, Health = 30, HouseId = 2}
            );
        }
    }
