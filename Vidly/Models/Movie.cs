using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    //    [Required] because Genre Genre does not exist in the database 
    //and here it is required field
    /// <summary>
    /// if we do migration the migration will be empty because
    /// //no differance between both GenreId and Genre
    /// </summary>
        public  Genre Genre { get; set; }
        //after we add this we have to do a migration
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

    }
}