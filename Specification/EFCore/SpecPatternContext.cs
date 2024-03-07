using Microsoft.EntityFrameworkCore;
using Specification.Logic.Movies;
using System.IO;
using System.Xml.Linq;

namespace Specification.EFCore;

public class SpecPatternContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Director { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Specification.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var marcWebb = new Director
        {
            Id = Guid.NewGuid(),
            Name = "Marc Webb"
        };
        var billCondon = new Director
        {
            Id = Guid.NewGuid(),
            Name = "Bill Condon"
        };
        var chrisRenaud = new Director
        {
            Id = Guid.NewGuid(),
            Name = "Chris Renaud"
        };
        var jonFavreau = new Director
        {
            Id = Guid.NewGuid(),
            Name = "Jon Favreau"
        };
        var mNightShyamalan = new Director
        {
            Id = Guid.NewGuid(),
            Name = "M. Night Shyamalan"
        };
        var alexKurtzman = new Director
        {
            Id = Guid.NewGuid(),
            Name = "Alex Kurtzman"
        };

        modelBuilder.Entity<Director>().HasData(
                marcWebb,
                 billCondon,
                chrisRenaud,
                jonFavreau,
                mNightShyamalan,
                alexKurtzman
          );

        modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Amazing Spider-Man",
                    ReleaseDate = new DateTime(2012, 07, 03),
                    MpaaRating = (MpaaRating)3,
                    Genre = "Adventure",
                    Rating = 7,
                    DirectorId = marcWebb.Id
                },
                new Movie()
                 {
                     Id = Guid.NewGuid(),
                     Name = "Beauty and the Beast",
                     ReleaseDate = new DateTime(2017, 03, 17),
                     MpaaRating = (MpaaRating)3,
                     Genre = "Family",
                     Rating = 7.8,
                     DirectorId = billCondon.Id
                 },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Secret Life of Pets",
                    ReleaseDate = new DateTime(2016, 07, 08),
                    MpaaRating = (MpaaRating)1,
                    Genre = "Adventure",
                    Rating = 6.6,
                    DirectorId = chrisRenaud.Id
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Jungle Book",
                    ReleaseDate = new DateTime(2016, 04, 15),
                    MpaaRating = (MpaaRating)2,
                    Genre = "Fantasy",
                    Rating = 7.5,
                    DirectorId = jonFavreau.Id
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Split",
                    ReleaseDate = new DateTime(2017, 01, 20),
                    MpaaRating = (MpaaRating)3,
                    Genre = "Horror",
                    Rating = 7.4,
                    DirectorId = mNightShyamalan.Id
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Mummy",
                    ReleaseDate = new DateTime(2017, 06, 09),
                    MpaaRating = (MpaaRating)4,
                    Genre = "Action",
                    Rating = 6.7,
                    DirectorId = alexKurtzman.Id
                }
           );
    }
}
