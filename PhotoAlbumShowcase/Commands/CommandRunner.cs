using PhotoAlbumShowcase.Photos;

namespace PhotoAlbumShowcase.Commands
{
    public class CommandRunner : ICommandRunner
    {
        private readonly IPhotoService _photoService;

        public CommandRunner(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<ICollection<Photo>> Execute(CommandType command, int id = 0, string commandText = "")
        {
            ICollection<Photo> photos = new List<Photo>();

            if (command.Equals(CommandType.GetAll))
            {
                photos = await _photoService.GetPhotos();
                DisplayPhotos(photos);
            }
            else if (command.Equals(CommandType.GetByAlbumId))
            {
                photos = await _photoService.GetPhotosByAlbum(id);
                DisplayPhotos(photos);
            }
            else if (command.Equals(CommandType.GetById))
            {
                photos = await _photoService.GetPhoto(id);
                DisplayPhotos(photos);
            }
            else if (command.Equals(CommandType.Help))
            {
                DisplayHelpText();
            }
            else if (command.Equals(CommandType.Unknown))
            {
                Console.WriteLine($"{commandText} is not a recognized command, please try again or type help for more info.");
            }

            return photos;
        }

        private void DisplayHelpText()
        {
            Console.WriteLine("");
            Console.WriteLine("*********************** Documentation ***********************");
            Console.WriteLine("");
            Console.WriteLine("Below is a list of possible commands to run:");
            Console.WriteLine("");
            Console.WriteLine("all - This command takes no following parameters and will simply display all photos available.");
            Console.WriteLine("");
            Console.WriteLine("album - (e.g. album 3)  This command will display all the photos with an albumId of 3.");
            Console.WriteLine("");
            Console.WriteLine("photo - (e.g. photo 2)  This command will display the photos with an id of 2.");
            Console.WriteLine("");
            Console.WriteLine("help - (e.g. help)  This command will display this help documentation.");
            Console.WriteLine("");
            Console.WriteLine("exit - (e.g. exit)  This command will stop the applciation.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter annother command to find more photos or type exit to quit.");
        }

        void DisplayPhotos(ICollection<Photo> photos)
        {
            Console.Clear();
            foreach (Photo photo in photos)
            {
                Console.WriteLine(photo.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Enter annother command to find more photos or type exit to quit.");
        }
    }
}
