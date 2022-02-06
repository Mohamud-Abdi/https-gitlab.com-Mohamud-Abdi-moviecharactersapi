using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Characters
{

    public class CharacterRepository : ICharacterRepository
    {
        private readonly MovieApiDbContext _db;

        public CharacterRepository(MovieApiDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _db.Characters
                   .Include(m => m.Movies)
                    .ToListAsync();
        }

        public async Task<Character> GetCharacter(int id)
        {

            var character = await _db.Characters.FindAsync(id);

            if (character == null)
            {
                return null;
            }

            return character;
        }
        public async Task PutCharacter(int id, Character character)
        {

            _db.Entry(character).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }


        public async Task DeleteCharacter(int id)
        {
            var character = await _db.Characters.FindAsync(id);
            _db.Characters.Remove(character);
            await _db.SaveChangesAsync();
        }




        public async Task<Character> PostCharacter(Character character)
        {
            _db.Characters.Add(character);
            await _db.SaveChangesAsync();

            return character;

        }



        public bool CharacterExists(int id)
        {
            return _db.Characters.Any(e => e.Id == id);
        }


    }
}
