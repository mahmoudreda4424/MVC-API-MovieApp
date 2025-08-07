using WebApp.Models;

namespace WebApp.Services
{
    public class MovieApiService
    {
        private readonly HttpClient _httpClient;
        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient=httpClientFactory.CreateClient("WebApiClient");

        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>("api/Movies");
            return movies ?? new List<Movie>();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _httpClient.GetFromJsonAsync<Movie>($"api/movies/{id}");
            return movie!;
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            var response = await _httpClient.PostAsJsonAsync("api/movies", movie);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/movies/{movie.Id}", movie);
            return response.IsSuccessStatusCode;
        }



        public async Task<bool> DeleteMovieAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Movies/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
