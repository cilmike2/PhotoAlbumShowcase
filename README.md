# PhotoAlbumShowcase

PhotoAlbumShowcase is a .net console application used to demonstrate basics skills in development.  The requirements were as follows:

- Create either a console or a UI application that displays photo ids and titles in an album.
- The photos are available in this web service: https://jsonplaceholder.typicode.com/photos.
- You can use any language or framework.
- You can use any open source libraries.
- Automated tests are encouraged.
- Post your solution on a free repository such as GitHub and send us a link.
- Provide a README that contains instructions on how to build and run your application.
- Spend as much (or little) time as you�d like on this.
- Feel free to use any resources available.


## Downloading

Simply clone this repository to download the source.

```bash
git clone 
```

## Prerequisites
This application is built on .Net 6 LTS, you must have the SDK installed in order to build the application.

## Usage

To build the project you can simply run:

```
dotnet build PhotoAlbumShowcase.csproj
```

After you have built the app navigate to the build ouput folder normally in the
```bin\debug\net8.0``` folder

Finally to start the app run:
```
dotnet .\PhotoAlbumShowcase.dll
```
The application will start to run and give you a basic instruction for how to get started.  At anytime you can type in the command ```help``` and it will provide you the following documentation

```
Below is a list of possible commands to run:

all - This command takes no following parameters and will simply display all photos available.

album - (e.g. album 3)  This command will display all the photos with an albumId of 3.

download - (e.g. download 2)  This command will download the photo with an id of 2.)

photo - (e.g. photo 2)  This command will display the photos with an id of 2.

help - (e.g. help)  This command will display this help documentation.

exit - (e.g. exit)  This command will stop the applciation.
```

## Roadmap
This yack has been shaved enough, it will now be put on the shelf for others to look at.

That being said here are some things I would do if I had more time to enrich the application:
1. I would abstract the console output so that I could write more unit tests for the output sent to it.
2. I would abstract the HttpClient dependency so that I could mock its results and test different scenarios for bad connections or failed requests.
3. I would build another implementation of the IPhotoService which would read the json from a local file on disk, or possibly have it get the data from the web and write it to disk and then have it get its information from the disk copy.  This could provide an "offline" mode to the app if desired.
## Contributing

Pull requests are welcome.

All pull requests will be denied if unit tests are not written or modified accordingly.

## License

[MIT](https://choosealicense.com/licenses/mit/)