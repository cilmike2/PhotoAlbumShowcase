using NSubstitute;
using PhotoAlbumShowcase.Commands;
using PhotoAlbumShowcase.Photos;
using Xunit;

namespace PhotoAlbumShowcaseTests.Commands
{
    public class CommandRunnerTests
    {

        IPhotoService _photoService;

        public CommandRunnerTests()
        {
            _photoService = Substitute.For<IPhotoService>();
        }

        [Fact]
        public void Exectue_givenAllCommand_CallsGetAllPhotos()
        {
            CommandRunner runner = new CommandRunner(_photoService);

            runner.Execute(CommandType.GetAll);

            _photoService.Received(1).GetPhotos();
        }

        [Fact]
        public void Exectue_GivenGetByAlbumIdCommand_CallsGetByAlbumId()
        {
            CommandRunner runner = new CommandRunner(_photoService);

            runner.Execute(CommandType.GetByAlbumId);

            _photoService.Received(1).GetPhotosByAlbum(Arg.Any<int>());
        }

        [Fact]
        public void Exectue_GivenGetByIdCommand_CallsGetPhoto()
        {
            CommandRunner runner = new CommandRunner(_photoService);

            runner.Execute(CommandType.GetById);

            _photoService.Received(1).GetPhoto(Arg.Any<int>());
        }

        [Fact]
        public void Exectue_GivenHelpCommand_DoesNotCallPhotoService()
        {
            CommandRunner runner = new CommandRunner(_photoService);

            runner.Execute(CommandType.Help);

            _photoService.DidNotReceive().GetPhoto(Arg.Any<int>());
            _photoService.DidNotReceive().GetPhotos();
            _photoService.DidNotReceive().GetPhotosByAlbum(Arg.Any<int>());
        }

        [Fact]
        public void Exectue_GivenUnknownCommand_DoesNotCallPhotoService()
        {
            CommandRunner runner = new CommandRunner(_photoService);

            runner.Execute(CommandType.Unknown);

            _photoService.DidNotReceive().GetPhoto(Arg.Any<int>());
            _photoService.DidNotReceive().GetPhotos();
            _photoService.DidNotReceive().GetPhotosByAlbum(Arg.Any<int>());
        }

    }
}