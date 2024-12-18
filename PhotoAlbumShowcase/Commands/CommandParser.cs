namespace PhotoAlbumShowcase.Commands;

public class CommandParser : ICommandParser
{
    public CommandType ParseCommand(string commandText)
    {
        var Command = commandText.Split(' ').First();

        return Command switch
        {
            "all" => CommandType.GetAll,
            "album" => CommandType.GetByAlbumId,
            "photo" => CommandType.GetById,
            "help" => CommandType.Help,
            "exit" => CommandType.Exit,
            _ => CommandType.Unknown,
        };
    }

}