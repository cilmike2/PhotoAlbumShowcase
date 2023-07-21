namespace PhotoAlbumShowcase.Commands
{
    internal interface ICommandParser
    {
        public CommandType ParseCommand(string commandText);
    }
}
