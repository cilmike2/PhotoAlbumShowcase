namespace PhotoAlbumShowcase.Commands
{
    public class CommandParser : ICommandParser
    {
        public CommandType ParseCommand(string commandText)
        {
            var Command = commandText.Split(' ').First();

            if (!string.IsNullOrEmpty(Command))
            {
                if (Command == "all")
                {
                    return CommandType.GetAll;
                }
                else if (Command == "album")
                {
                    return CommandType.GetByAlbumId;
                }
                else if (Command == "photo")
                {
                    return CommandType.GetById;
                }
                else if (Command == "help")
                {
                    return CommandType.Help;
                }
                else if (Command == "exit")
                {
                    return CommandType.Exit;
                }
            }

            return CommandType.Unknown;
        }
    }
}
