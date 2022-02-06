using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.Models.DTOs.Character
{
    public class CharacterReadDTO
    {

        //Id
        public int Id { get; set; }

        //Fields
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }
        public string Gender { get; set; }


        //Relationsips
        public List<int> Movies { get; set; }
    }
}
