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
              new Character { Id = 1, FirstName = "Idris", LastName="Elba", Alias = "Elb", Gender = "Male", Picture = "url" },
              new Character { Id = 2, FirstName = "Isabelle", LastName = "Fuhrman", Alias = "Isa", Gender = "Female", Picture = "url" },
              new Character { Id = 3, FirstName = "Zack", LastName = "Snyder", Alias = "ZS", Gender = "Male", Picture = "url" }
                );


            // Seed Data for Movies

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Novice",
                    Genre = "Drama",
                    ReleaseYear = 2021,
                    Director = "Lauren Hadaway",
                    PictureURL = "https://www.imdb.com/title/tt11131464/?ref_=ttls_li_tt",
                    TrailerUrl = "https://www.imdb.com/title/tt11131464/?ref_=ttls_li_tt",
                    FranchiseId = 1
                });
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 2,
                    Title = "Zack Snyder's Justice League ",
                    Genre = "Thriller",
                    ReleaseYear = 2021,
                    Director = "Zack Snyder",
                    PictureURL = "https://www.imdb.com/title/tt12361974/?ref_=ttls_li_tt",
                    TrailerUrl = "https://www.imdb.com/title/tt12361974/?ref_=ttls_li_tt",
                    FranchiseId = 2
                });
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 3,
                    Title = "Spider-Man: No Way Home ",
                    Genre = "Action",
                    ReleaseYear = 2021,
                    Director = "John Watts",
                    PictureURL = "https://www.imdb.com/title/tt10872600/?ref_=ttls_li_tt",
                    TrailerUrl = "https://www.imdb.com/title/tt10872600/?ref_=ttls_li_tt",
                    FranchiseId = 3
                });


            // Seed Data for Franchises

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Star wars", Description = "G&K movies ar very entertaining and abit scary." });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Harry Potter", Description = "American superhero film featuring the Marvel Comics character Venom," });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "The Matrix", Description = " Movie is Based on the Marvel Comics superhero of the same name" });



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
    


