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
    
    Console.WriteLine("Welcome to the photo album showcase.  Enter a command now or type exit to close the app any time.");
    

    while (ContinueRunning)
    {
        var commandText = Console.ReadLine();
        
        var Commands = commandText.Split(' ');

        CommandType command = _commandParser.ParseCommand(Commands[0]);
        int id = 0;
        if(Commands.Length > 1)
        {
            id = int.Parse(Commands[1]);
        }
        
        if (command.Equals(CommandType.Exit))
        {
            ContinueRunning = false;
        } 
        else
        {
            try
            {
                var photos = await _commandRunner.Execute(command, id, commandText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error while executing your command, please try again.");
            }
        }
    }
    await _host.StopAsync();
}

