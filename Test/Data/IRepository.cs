using Test.Model;

namespace Test.Data
{
   
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class MovieRepository : IRepository<Movie>
    {
        private readonly List<Movie> _dataStore = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseDate = new DateOnly(2010, 7, 16) },
            new Movie { Id = 2, Title = "The Matrix", Genre = "Action", ReleaseDate = new DateOnly(1999, 3, 31) },
            new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", ReleaseDate = new DateOnly(2014, 11, 7) }
        };

        public IEnumerable<Movie> GetAll()
        {
            return _dataStore;
        }

        public Movie GetById(int id)
        {
            return _dataStore.FirstOrDefault(p => p.Id == id);
        }

      

        public void Add(Movie entity)
        {
            _dataStore.Add(entity);
        }

        public void Update(Movie entity)
        {
            var oldMovie = _dataStore.Find(p=>p.Id == entity.Id);
            if(oldMovie != null)
            {
                oldMovie.Title = entity.Title;
                oldMovie.Genre = entity.Genre;
                oldMovie.ReleaseDate = entity.ReleaseDate;
            }
        }
        public void Delete(int id)
        {
            var movie = _dataStore.Find(p=> p.Id== id);
            if(movie != null)
            {
                _dataStore.Remove(movie);
            }
        }

    }
}
