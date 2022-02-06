using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.Domain;
using Movie_Characters_API.Models.DTOs.Character;
using Movie_Characters_API.Models.DTOs.Franchise;
using Movie_Characters_API.Models.DTOs.Movies;
using MovieCharacters_API.Repositories.Franchises;

namespace MovieCharacters_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IMapper _mapper;

        public FranchisesController(IMapper mapper, IFranchiseRepository franchiseRepository )
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
           
                   }

        /// <summary>
        /// Lists all the franchises in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        { 
                return _mapper.Map<List<FranchiseReadDTO>>( await _franchiseRepository.GetFranchisesAsync());
        }


        /// <summary>
        /// Get all the movies in the  given Franchise (use franchise id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{id}/movies")]

        public   async Task<IEnumerable<MovieReadDTO>> GetMoviesInFranchise(int id)
        {


            return _mapper.Map<List<MovieReadDTO>>(await _franchiseRepository.GetMoviesInFranchiseAsync(id));


        }

        /// <summary>
        /// Get all the characters in the given franchis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}/characters")]
        public  async Task<IEnumerable<CharacterReadDTO>> GetCharactersInFranchise(int id)
        {



            return  _mapper.Map<List<CharacterReadDTO>>( await _franchiseRepository.GetCharactersInFranchiseAsync(id)) ;
        }

        /// <summary>
        /// updating list of movies in franchise.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Mids"></param>
        /// <returns></returns>

        [HttpPut("{id}/movies")]
        public  Task UpdateMovieInFranchise(int id, int[] Mids)
        {
           return   _franchiseRepository.UpdateMovieInFranchiseAsync(id, Mids);
        }



        /// <summary>
        /// Returns a franchise with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchise = _mapper.Map<FranchiseReadDTO>(await _franchiseRepository.GetFranchiseAsync(id));

            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
        }

        /// <summary>
        ///  Updates a Franchise with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseUpdateDTo franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }


            Franchise franchiseDomain = _mapper.Map<Franchise>(franchise);

            try
            {

              await  _franchiseRepository.PutFranchiseAsync(id, franchiseDomain);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Posts  a franchise to the database.
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO franchise)
        {

            Franchise createDomain= _mapper.Map<Franchise>(franchise);
           await _franchiseRepository.PostFranchiseAsync(createDomain);
           return CreatedAtAction("GetFranchise", new { id = franchise }, franchise);
        }
        /// <summary>
        /// Deletes a fracnhise with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
           

           await  _franchiseRepository.DeleteFranchiseAsync(id);  
            

            return NoContent();
        }
        /// <summary>
        /// Checks if a Franchise exists in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool FranchiseExists(int id)
        {
            return _franchiseRepository.FranchiseExists(id);
        }
    }
}
