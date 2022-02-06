using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Movies
{
    public interface IMovieRepository
    {


        public Task<IEnumerable<Movie>> GetMoviesAsync();
        public Task<Movie> GetMovieAsync(int id);
        public Task PutMovieAsync(int id, Movie movie);
        public Task<Movie> PostMovieAsync(Movie movie);
        public Task DeleteMovieAsync(int id);
        public bool MovieExists(int id);
        public Task<IEnumerable<Character>> GetCharactersInMovieAsync(int id);
        public Task UpdateCharacterInMovieAsync(int id, int[] character);




    }
}
