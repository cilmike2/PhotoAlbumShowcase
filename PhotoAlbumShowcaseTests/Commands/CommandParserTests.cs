using PhotoAlbumShowcase.Commands;
using Xunit;

namespace PhotoAlbumShowcaseTests.Commands
{
    public class CommandParserTests
    {
        [Fact]
        public void ParseCommand_GiveBadText_ReturnsUnknown()
        {
            CommandParser parser = new CommandParser();

            var result = parser.ParseCommand("test");

            Assert.Equal(CommandType.Unknown, result);
        }

        [Fact]
        public void ParseCommand_GiveEmptyText_ReturnsUnknown()
        {
            CommandParser parser = new CommandParser();

            var result = parser.ParseCommand("");

            Assert.Equal(CommandType.Unknown, result);
        }

        [Fact]
        public void ParseCommand_GiveHelp_ReturnsHelpCommand()
        {
            CommandParser parser = new CommandParser();

            var result = parser.ParseCommand("help");

            Assert.Equal(CommandType.Help, result);
        }

        [Fact]
        public void ParseCommand_GiveAlbum_ReturnsGetByAlbumId()
        {
            CommandParser parser = new CommandParser();

            var result = parser.ParseCommand("album");

            Assert.Equal(CommandType.GetByAlbumId, result);
        }

        [Fact]
        public void ParseCommand_GivePhoto_ReturnsGetById()
        {
            CommandParser parser = new CommandParser();

            var result = parser.ParseCommand("photo");

            Assert.Equal(CommandType.GetById, result);
        }

        [Fact]
        public void ParseCommand_GiveAll_ReturnsGetAll()
        {
            CommandParser parser = new CommandParser();

            var result = parser.ParseCommand("all");

            Assert.Equal(CommandType.GetAll, result);
        }
    }
}