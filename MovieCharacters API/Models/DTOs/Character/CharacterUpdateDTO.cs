using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.Models.DTOs.Character
{
    public class CharacterUpdateDTO
    {

        //Id
        public int Id { get; set; }

        //Fields
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }

        [MaxLength(15)]
        public string Gender { get; set; }

      
    }
}
