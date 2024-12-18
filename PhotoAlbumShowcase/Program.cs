// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhotoAlbumShowcase.Commands;
using PhotoAlbumShowcase.Photos;

bool ContinueRunning = true;
IPhotoService _photoService;
ICommandParser _commandParser;
ICommandRunner _commandRunner;
IHost _host;
string[] commandArgs = args;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
ConfigureHost(builder);

// Setup Services
SetupServices();

await RunMainLoop();

void ConfigureHost(HostApplicationBuilder host)
{
    builder.Logging.AddConsole();

    builder.Services.AddTransient<IPhotoService, WebPhotoService>();
    builder.Services.AddTransient<ICommandParser, CommandParser>();
    builder.Services.AddTransient<ICommandRunner, CommandRunner>();

    IHostEnvironment env = builder.Environment;


    builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


    builder.Services.AddHttpClient("Photos", httpClient =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration["photoApiUrl"]);
    });

    _host = builder.Build();
}

void SetupServices()
{
    using IServiceScope serviceScope = _host.Services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    _photoService = provider.GetRequiredService<IPhotoService>();
    _commandParser = provider.GetRequiredService<ICommandParser>();
    _commandRunner = provider.GetRequiredService<ICommandRunner>();
}

async Task RunMainLoop()
{
    
    Console.WriteLine("Welcome to the photo album showcase.  Enter a command now or type exit to close the app any time. You may also type 'help' any time for more information.");
    

    while (ContinueRunning)
    {
        var commandText = Console.ReadLine();

        var Commands = commandText.Split(' ');

        CommandType command = _commandParser.ParseCommand(Commands[0]);
        
        int photoIdParameter = ParsePhotoIdParameter(Commands);

        if (command != CommandType.Exit)
        {
            await ExectueCommand(_commandRunner, commandText, command, photoIdParameter);
        }
        else
        {
            ContinueRunning = false;
        }
        
    }
    await _host.StopAsync();
}

static int ParsePhotoIdParameter(string[] Commands)
{
    int photoIdParameter = 0;
    if (Commands.Length > 1)
    {
        photoIdParameter = int.Parse(Commands[1]);
    }

    return photoIdParameter;
}

static async Task ExectueCommand(ICommandRunner _commandRunner, string? commandText, CommandType command, int photoIdParameter)
{
    try
    {
        var photos = await _commandRunner.Execute(command, photoIdParameter, commandText);
    }
    catch (Exception)
    {
        Console.WriteLine("There was an error while executing your command, please try again.");
    }
}