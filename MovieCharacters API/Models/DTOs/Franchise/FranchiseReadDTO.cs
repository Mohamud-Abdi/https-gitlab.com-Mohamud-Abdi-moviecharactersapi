using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie_Characters_API.Models.DTOs.Franchise
{
    public class FranchiseReadDTO
    {
        //Id
        public int Id { get; set; }
        //Fields
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        //Relationships
        public List<int> Movies { get; set; }
    }
}
