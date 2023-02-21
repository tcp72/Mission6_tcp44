using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_tcp44.Models //name of the program. folder stored in (Models)
{
    public class MovieEntry //public means other classes can see it; class (it's a class); name of the model = MovieEntry
    {

        //stuff for Joel Hilton Movie Collection
        [Key]
        [Required]
        public int MovieId { get; set; } //this is to be used as a primary key

        [Required(ErrorMessage ="You must enter a movie title")]
        public string Title { get; set; } //HERE IS THE TITLE!

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        //Edited, lent, notes fields are optional
        public bool Edited { get; set; }
        public string Lent { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

        //Build foreign key relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; } //declare Category type named "Category"; an instance of "Category"

    }
}
