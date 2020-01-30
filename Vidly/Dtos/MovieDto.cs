using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
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
        //after we add this we have to do a migration
       
        [Required]
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }

     
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
      
        public byte NumberInStock { get; set; }
    }
}