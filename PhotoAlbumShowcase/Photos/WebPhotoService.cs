using System.Text.Json;

namespace PhotoAlbumShowcase.Photos
{
    public class WebPhotoService : IPhotoService
    {
        private HttpClient _httpClient;

        public WebPhotoService(IHttpClientFactory httpClientFactory)
        {
            // this code gets the named http client 'Photos' from the startup configuration
            _httpClient = httpClientFactory.CreateClient("Photos");
        }

        public async Task<string> DownloadPhoto(int id)
        {
            var photo = await CallHttpEndpoint($"photos?id={id}");

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var photoPath = Path.Combine(desktopPath, $"Photo_{photo.First().Id}.jpg");

            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(photo.First().Url, photoPath);
            }

            return photoPath;
        }

        public async Task<ICollection<Photo>> GetPhoto(int id)
        {
            return await CallHttpEndpoint($"photos?id={id}");
        }

        public async Task<ICollection<Photo>> GetPhotos()
        {
            return await CallHttpEndpoint("photos");
        }

        public async Task<ICollection<Photo>> GetPhotosByAlbum(int albumId)
        {
            return await CallHttpEndpoint($"photos?albumId={albumId}");
        }

        private async Task<ICollection<Photo>> CallHttpEndpoint(string parameters)
        {
            var response = await _httpClient.GetAsync(parameters);
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Photo[]>(content);
        }
    }
}
