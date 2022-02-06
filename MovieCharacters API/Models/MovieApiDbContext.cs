using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Movie_Characters_API.Models
{
    public class MovieApiDbContext : DbContext
    {

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

       

        public MovieApiDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Seed Data for Character

            modelBuilder.Entity<Character>().HasData(
              new Character { Id = 1, FirstName = "Gorilla", LastName="Monk", Alias = "Monkey", Gender = "Male", Picture = "url" },
              new Character { Id = 2, FirstName = "Adam", LastName = "Monk", Alias = "SuperMan", Gender = "Male", Picture = "url" },
              new Character { Id = 3, FirstName = "Anthony", LastName = "Monk", Alias = "Marvel", Gender = "Male", Picture = "url" }
                );


            // Seed Data for Movies

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Godzilla vs. Kong",
                    Genre = "Test",
                    ReleaseYear = 2021,
                    Director = "Adam Wingard",
                    PictureURL = "https://viniloblog.com/wp-content/uploads/2021/02/godzilla-vs-kong-luchan.jpg",
                    TrailerUrl = "https://youtu.be/4adYOnlWYQg?t=21",
                    FranchiseId = 1
                });
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 2,
                    Title = "Venom: Let There Be Carnage",
                    Genre = "test",
                    ReleaseYear = 2021,
                    Director = "Andy Serkis",
                    PictureURL = "https://tse4.mm.bing.net/th/id/OIP.Ji1Doi8I9f8DrIxEW33BFwHaFj?pid=ImgDet&rs=1",
                    TrailerUrl = "https://www.imdb.com/video/vi1533394969?playlistId=tt7097896&ref_=tt_pr_ov_vi",
                    FranchiseId = 2
                });
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 3,
                    Title = "Daredevil",
                    Genre = "test",
                    ReleaseYear = 2003,
                    Director = "Mark Steven Johnson",
                    PictureURL = "https://i.ytimg.com/vi/7VZAiCvenmo/maxresdefault.jpg",
                    TrailerUrl = "https://www.imdb.com/video/vi2778726681?playlistId=tt0287978&ref_=tt_ov_vi",
                    FranchiseId = 3
                });


            // Seed Data for Franchises

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "G&K", Description = "G&K movies ar very entertaining and abit scary." });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Venom", Description = "American superhero film featuring the Marvel Comics character Venom," });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "Dare", Description = " Movie is Based on the Marvel Comics superhero of the same name" });



            // Relationship between movie and franchise with foreign key

            modelBuilder.Entity<Movie>()
            .HasOne(l => l.Franchise)
            .WithMany(r => r.Movies)
            .HasForeignKey(f => f.FranchiseId)
            .OnDelete(DeleteBehavior.SetNull);


            // m2m relationship between movies and characters. Need to define m2m and access linking table

            modelBuilder.Entity<Movie>()
              .HasMany(p => p.Characters)
              .WithMany(m => m.Movies)
              .UsingEntity<Dictionary<string, object>>(
                  "MovieCharacter",
                  r => r.HasOne<Character>().WithMany().HasForeignKey("CharactersId"),
                  l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                  je =>
                  {
                      je.HasKey("MoviesId", "CharactersId");
                      je.HasData(
                          new { CharactersId = 1, MoviesId = 1 },
                          new { CharactersId = 2, MoviesId = 2 },
                          new { CharactersId = 3, MoviesId = 3 });

                  });

        }
    }


}
    


