using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Characters
{
    public interface ICharacterRepository
    {
        public Task<IEnumerable<Character>> GetCharacters();
        public Task<Character> GetCharacter(int id);
        public Task  PutCharacter(int id, Character character);
        public Task<Character> PostCharacter(Character character);
        public Task DeleteCharacter(int id);
        public bool CharacterExists(int id);



    }
}
