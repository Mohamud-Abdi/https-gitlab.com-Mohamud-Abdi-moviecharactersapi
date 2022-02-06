using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Characters_API.Models.Domain
{
    public class Character
    {
        //Id
        public int Id { get; set; }

        //Fields
        [MaxLength(25)]
        public string  FirstName { get; set; }

        [MaxLength(25)]
        public string  LastName { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }

        [MaxLength(15)]
        public string Gender { get; set; }
        public string Picture { get; set; }

        //Relationsips
        public ICollection<Movie> Movies { get; set; }
       

    }
}
