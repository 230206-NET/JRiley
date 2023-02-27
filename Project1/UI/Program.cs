using Services;
using DataAccess;
using Serilog;
using UI;

// namespace UI;

// public class Program {
//     public static void Main(string[] args){
//         new StartMenu(new UserService(new FileStorage())).Begin();
//     }
// }

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

    try {
        Log.Information("Application Starting...");

        IRepository repo = new FileStorage();

        UserService service = new UserService(repo);

        StartMenu menu = new StartMenu(service);

        menu.Begin();
    }

    catch(Exception ex){
        Log.Error("Error! Something fatal happened, {0}", ex);
    }
    finally {
        Log.CloseAndFlush();
    }
