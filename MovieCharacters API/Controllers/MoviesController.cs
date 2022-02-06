
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
using Movie_Characters_API.Models.DTOs.Movies;
using MovieCharacters_API.Repositories.Movies;

namespace MovieCharacters_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMapper mapper, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;

        }
        /// <summary>
        ///   Lists all the Movies in the system.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {

            return _mapper.Map<List<MovieReadDTO>>(await _movieRepository.GetMovies());
        }

        /// <summary>
        /// Get characters in a movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}/characters")]
        public async Task<IEnumerable<CharacterReadDTO>> GetCharactersInMovie(int id)
        {
            return _mapper.Map<List<CharacterReadDTO>>( await _movieRepository.GetCharactersInMovie(id)); 
        }


        /// <summary>
        /// update list of characters in a movie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
      
        [HttpPut("{id}/characters")]
        public async Task UpdateCharacterInMovie(int id, int[] characterIds)
        {
            await _movieRepository.UpdateCharacterInMovie(id, characterIds);
         }



            /// <summary>
            /// 
            /// Returns the Movie with the given id.
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {

            var movie = _mapper.Map<MovieReadDTO>( await _movieRepository.GetMovie(id));

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
        /// <summary>
        /// Updates the Movie with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

           Movie domainMovie = _mapper.Map<Movie>(movie);
            try
            {
              await  _movieRepository.PutMovie(id, domainMovie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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
        /// Posts a Movie to the database.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO movie)
        {

            Movie domain = _mapper.Map<Movie>(movie);

           await _movieRepository.PostMovie(domain); 

            return CreatedAtAction("GetMovie", new { id = movie }, movie);
        }

        /// <summary>
        ///  Deletes the Movie with the passed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
           await _movieRepository.DeleteMovie(id);
            return NoContent();
        }

        /// <summary>
        /// Checks if movie exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MovieExists(int id)
        {
            return _movieRepository.MovieExists(id);

        }
    }
}
