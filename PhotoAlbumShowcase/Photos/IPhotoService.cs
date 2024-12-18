namespace PhotoAlbumShowcase.Photos
{
    public interface IPhotoService
    {
        Task<ICollection<Photo>> GetPhotos();

        Task<ICollection<Photo>> GetPhotosByAlbum(int albumId);

        Task<ICollection<Photo>> GetPhoto(int id);

        Task<string> DownloadPhoto(int id);
    }
}
