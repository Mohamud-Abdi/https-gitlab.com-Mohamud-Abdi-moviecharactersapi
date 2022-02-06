using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Characters
{
    public interface ICharacterRepository
    {
        public Task<IEnumerable<Character>> GetCharactersAsync();
        public Task<Character> GetCharacterAsync(int id);
        public Task  PutCharacterAsync(int id, Character character);
        public Task<Character> PostCharacterAsync(Character character);
        public Task DeleteCharacterAsync(int id);
        public bool CharacterExists(int id);



    }
}
