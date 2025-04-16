using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout.Model;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Workout.Model.User> User { get; set; } = default!;
        public DbSet<Workout.Model.Exercise> Exercise {get;set;} = default!;
        public DbSet<Workout.Model.WorkoutLog> WorkoutLog{get;set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
              new User { Id=1, Name="Kyle Morrill", Email="morrilk@mail.nmc.edu"},
              new User {Id=2, Name= "Lisa Balbach", Email="lbalbach@nmc.edu"}
            );
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise{Id=1, Name= "Legs", Type=Workout.Model.Type.Strength, MuscleGroup="Quads", Reps=15, Sets=3},
                new Exercise{Id=2, Name ="Legs", Type=Workout.Model.Type.Strength, MuscleGroup="Hamstrings", Reps=15, Sets=3},
                new Exercise{Id=3, Name ="Abs", Type=Workout.Model.Type.Strength, MuscleGroup="Abs", Reps=100, Sets=3},
                new Exercise{Id=4, Name ="Arms", Type=Workout.Model.Type.Strength, MuscleGroup="Biceps", Reps=10, Sets=3},
                new Exercise{Id=5, Name ="Speed Walking", Type=Workout.Model.Type.Cardio, MuscleGroup="All", Duration=120}
            );
            modelBuilder.Entity<WorkoutLog>().HasData(
                new WorkoutLog{Id = 1, Date=DateTime.Today, UserId = 1, ExerciseId = 1},
                new WorkoutLog {Id = 2, Date = DateTime.Today, UserId = 1, ExerciseId = 2}
            );
        }
    }
