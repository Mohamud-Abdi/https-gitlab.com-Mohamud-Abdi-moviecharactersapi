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
using MovieCharacters_API.Repositories.Characters;
using MovieCharacters_API.Repositories.Franchises;

namespace MovieCharacters_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterController( IMapper mapper, ICharacterRepository context)
        {
            _characterRepository = context;
            _mapper = mapper;    
        }

        /// <summary>
        ///  API call to list all the characters in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _characterRepository.GetCharacters());
        }


        /// <summary>
        ///   Fetches the character with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            return _mapper.Map<CharacterReadDTO>( await _characterRepository.GetCharacter(id));
            
        }

        /// <summary>
        ///  Updates the character with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterUpdateDTO character)
        {
           
            if (!_characterRepository.CharacterExists(id))
            {
                return NotFound();
            }
            Character domainCreate = _mapper.Map<Character>(character);
            if (id == character.Id)
            {
                return BadRequest();
            }

            await _characterRepository.PutCharacter(id, domainCreate);
        
           
            return NoContent();
        }

        /// <summary>
        ///Posts a Character to the database.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO character)
        {
            Character domainCreate = _mapper.Map<Character>(character);
            await _characterRepository.PostCharacter( domainCreate);


          return CreatedAtAction("GetCharacter", new { id = domainCreate.Id }, character);
        }

        /// <summary>
        /// 
        ///  Deletes the character with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {


          await  _characterRepository.DeleteCharacter(id);

            return  NoContent();
        }

        /// <summary>
        /// Checks if character with the given id exists 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CharacterExists(int id)
        {
          return _characterRepository.CharacterExists(id);   

        }
    }
}
