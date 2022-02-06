using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models.DTOs.Movies
{
    public class MovieReadDTO
    {
        public int Id { get; set; }

        //Fields
        [MaxLength(100)]
        public string Title { get; set; }
        public string Genre { get; set; }
        [MaxLength(4)]
        public int ReleaseYear { get; set; }
        [MaxLength(25)]
        public string Director { get; set; }
        [Url]
        public string PictureURL { get; set; }
        [Url]
        public string TrailerUrl { get; set; }

        // Members
        public List<int> Characters { get; set; }


    }
}
