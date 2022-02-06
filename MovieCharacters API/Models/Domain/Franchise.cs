using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models.Domain
{
    public class Franchise
    {
        //Id
        public int Id { get; set; }
        //Fields
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string   Description { get; set; }

       //Relationships
        public ICollection<Movie> Movies { get; set; }

    }
}
