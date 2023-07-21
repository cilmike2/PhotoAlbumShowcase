using PhotoAlbumShowcase.Photos;

namespace PhotoAlbumShowcase.Commands
{
    public interface ICommandRunner
    {
        Task<ICollection<Photo>> Execute(CommandType command, int id = 0, string commandText = "");
    }
}
