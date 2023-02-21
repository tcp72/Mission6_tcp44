using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_tcp44.Models
{
    public class MovieLibraryDatabaseContext : DbContext
    {
        //constructor
        public MovieLibraryDatabaseContext (DbContextOptions<MovieLibraryDatabaseContext> options) : base (options) //this is the constructor method that returns nothing
        {       //call the constructor; when call constructor, must receive a DBCOntextOptions of type DateApplicationContext; 
                                //then what we want to name the variable (options); that inherits from the base dbContextOptions type
                //leave blank for now
        }
        //create a database set; the unit in which we're going to pull from the database
        //remember how passing all info to the model in an object?
        public DbSet<MovieEntry> responses { get; set; }
        public DbSet<Category> Categories { get; set; } //make a set of type "Category" and call it "Categories"
        //seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData( //Make sure there isn't already data as add this in)
                new Category { CategoryID = 1, CategoryName= "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
            );
            mb.Entity<MovieEntry>().HasData( //name of model is MovieEntry; if there is data then . . . 
                new MovieEntry //model
                {
                    MovieId = 1,
                    CategoryID = 1,
                    Title = "Get Smart",
                    Year = 2004,
                    Director = "John",
                    Rating = "PG-13",
                    Edited = true,
                    Lent = "my sister",
                    Notes = "This is a great show!"
                },
                new MovieEntry
                {
                    MovieId = 2,
                    CategoryID = 2,
                    Title = "Nacho Libre",
                    Year = 2005,
                    Director = "Matt",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "dad",
                    Notes = "Super funny!"
                },
                new MovieEntry
                {
                    MovieId = 3,
                    CategoryID = 3,
                    Title = "Top Gun",
                    Year = 2022,
                    Director = "Smithson",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "mom",
                    Notes = "One of the greats!"
                }

                ) ;
        }
    }   //make public DbSet of the MovieEntry (model name) response type; name it responses (or anything); allow us to get or set responses;
}       //This can return a set of data from our database (in list format??)
