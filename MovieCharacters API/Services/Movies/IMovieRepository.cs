using Movie_Characters_API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCharacters_API.Repositories.Movies
{
    public interface IMovieRepository
    {


        public Task<IEnumerable<Movie>> GetMovies();
        public Task<Movie> GetMovie(int id);
        public Task PutMovie(int id, Movie movie);
        public Task<Movie> PostMovie(Movie movie);
        public Task DeleteMovie(int id);
        public bool MovieExists(int id);
        public Task<IEnumerable<Character>> GetCharactersInMovie(int id);
        public Task UpdateCharacterInMovie(int id, int[] character);




    }
}
