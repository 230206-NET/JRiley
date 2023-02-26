using System.Text.Json;

using Serilog;

using Models;

namespace DataAccess;

public class FileStorage : IRepository 
{

    private const string _filePath = "../DataAccess/UserLogs.json";

    public FileStorage(){
        Log.Information("Opening file storage system...");
        bool fileExists = File.Exists(_filePath);

        if (!fileExists) {
            var fs = File.Create(_filePath);
            fs.Close();
        }
    }
    public List<Employee> GetEveryUser(){
        
        Log.Information("File Storage: Retrieving Employee Session...");
        string? fileContent = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Employee>>(fileContent);

    }

    public Employee AddUser(Employee user){

        Console.WriteLine("Creating account for " + user.empName);
        

        List<Employee> userList = GetEveryUser();

        userList.Add(user);


        string userInfo = JsonSerializer.Serialize(userList);
        File.WriteAllText(_filePath, userInfo);
        return user;
    }
    
} 