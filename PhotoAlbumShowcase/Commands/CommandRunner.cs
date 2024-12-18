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

            switch (command)
            {
                case CommandType.GetAll:
                    photos = await _photoService.GetPhotos();
                    Console.Clear();
                    DisplayPhotos(photos);
                    break;
                case CommandType.GetByAlbumId:
                    photos = await _photoService.GetPhotosByAlbum(id);
                    Console.Clear();
                    DisplayPhotos(photos);
                    break;
                case CommandType.GetById:
                    photos = await _photoService.GetPhoto(id);
                    Console.Clear();
                    DisplayPhotos(photos);
                    break;
                case CommandType.Download:
                    var photoPath = await _photoService.DownloadPhoto(id);
                    Console.Clear();
                    Console.WriteLine($"Photo {id} has been downloaded to {photoPath}.");
                    break;
                case CommandType.Help:
                    DisplayHelpText();
                    break;
                case CommandType.Unknown:
                    Console.WriteLine($"{commandText} is not a recognized command, please try again or type help for more info.");
                    break;
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
            Console.WriteLine("download - (e.g. download 34)  This command will download the image to the current users desktop and then display the path that it was saved to.");
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
