namespace PhotoAlbumShowcase.Commands;

public class CommandParser : ICommandParser
{
    public CommandType ParseCommand(string commandText)
    {
        return commandText switch
        {
            "all" => CommandType.GetAll,
            "album" => CommandType.GetByAlbumId,
            "download" => CommandType.Download,
            "help" => CommandType.Help,
            "photo" => CommandType.GetById,
            "exit" => CommandType.Exit,
            _ => CommandType.Unknown,
        };
    }

}