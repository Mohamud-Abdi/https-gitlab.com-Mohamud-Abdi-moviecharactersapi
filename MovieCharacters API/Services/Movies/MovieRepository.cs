using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieApiDbContext _db;

        public MovieRepository(MovieApiDbContext db)
        {
            _db = db;
        }



        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _db.Movies
                .Include(c => c.Characters)
                .ToListAsync();

        }
        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie == null)
                return null;
            return movie;

        }
        public async Task PutMovie(int id, Movie movie)
        {

            _db.Entry(movie).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<Movie> PostMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
            return movie;


        }
        public async Task DeleteMovie(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }

        public bool MovieExists(int id)
        {
            return _db.Movies.Any(e => e.Id == id);


        }

        public async Task<IEnumerable<Character>> GetCharactersInMovie(int id)
        {
            var movies = await _db.Movies
                        .Include(c => c.Characters)
                        .FirstOrDefaultAsync(i => i.Id == id);

            if (movies == null)
            {
                return null;
            }
            var characters =  _db.Characters.Where(f => f.Id == movies.Id);

            return await characters.ToListAsync();



        }

        public async Task UpdateCharacterInMovie(int id, int[] characterId)
        {

            var movie = await _db.Movies
                        .Include(c => c.Characters)
                        .FirstOrDefaultAsync(e => e.Id == id);
            if (movie == null)
            {
                return; }

            // filters duplicates in the passed array.
            var distinctIds = characterId.Distinct();
            var characters = movie.Characters.Where(character => distinctIds.Any(e => character.Id == id)).ToList();

            var nonCharacters = distinctIds.Where(id => !characters.Any(character=> character.Id == id));

            if (nonCharacters.Count() > 0)
                return;

            movie.Characters = characters;
            await _db.SaveChangesAsync();

            
        }
    }
}
