using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TrainDilemma.Services;
using TrainDilemma.Services.interfaces;
public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ITrainComposition, TrainCompositionService>()
            .BuildServiceProvider();

        var logger = serviceProvider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();

        logger.LogDebug("Starting application");

       
        var trainManager = serviceProvider.GetService<ITrainComposition>();



        trainManager.AttachLeft(1);
        trainManager.AttachLeft(3);
        trainManager.AttachRight(5);

        
        Console.WriteLine(string.Join(", ", trainManager.GetTrainCarriages()));

        trainManager.DetachLeft();

        Console.WriteLine(string.Join(", ", trainManager.GetTrainCarriages()));

        logger.LogDebug("Train Left then stattion!");

    }
}