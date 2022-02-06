using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models.Domain
{
    public class Movie
    {
        //Id
        public int Id { get; set; }

        //Fields
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(25)]
        public string Director { get; set; }
        [Url]
        public string PictureURL { get; set; }
        [Url]
        public  string TrailerUrl { get; set; }

        // Relationships
        public ICollection<Character> Characters { get; set; }
        public int? FranchiseId { get; set; }
       public Franchise Franchise { get; set; }

    }
}
