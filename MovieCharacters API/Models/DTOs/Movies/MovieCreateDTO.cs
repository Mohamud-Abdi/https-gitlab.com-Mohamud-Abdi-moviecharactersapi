using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models.DTOs.Movies
{
    public class MovieCreateDTO
    {


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
        public string TrailerUrl { get; set; }

    }
}
