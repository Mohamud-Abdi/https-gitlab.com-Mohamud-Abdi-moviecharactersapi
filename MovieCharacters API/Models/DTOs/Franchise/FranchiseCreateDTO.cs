
using System.ComponentModel.DataAnnotations;



namespace Movie_Characters_API.Models.DTOs.Franchise
{
    public class FranchiseCreateDTO
    {
        //Fields
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

    }
}
