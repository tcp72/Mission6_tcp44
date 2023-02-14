using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_tcp44.Models //name of the program. folder stored in (Models)
{
    public class MovieEntry //public means other classes can see it; class (it's a class); name of the model = MovieEntry
    {
        //[Key]
        //[Required]
        //public int MovieId { get; set; } //this is to be used as a primary key
        //public string FirstName { get; set; } 
        //public string LastName { get; set; }
        //public byte Age { get; set; } //byte data type is 0-255 (like int but smaller)
        //public string Phone { get; set; }
        //public string Major { get; set; }
        //public bool CreeperStalker { get; set; } //see if they are creeper/stalker

        //stuff for Joel Hilton Movie Collection
        [Key]
        [Required]
        public int MovieId { get; set; } //this is to be used as a primary key

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

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

    }
}
