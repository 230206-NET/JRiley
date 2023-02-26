using Services;
using DataAccess;
using Serilog;

namespace UI;

public class Program {
    public static void Main(string[] args){
        new StartMenu(new UserService(new FileStorage())).Begin();
    }
}