// See https://aka.ms/new-console-template for more information

using DataAccess;
using Models;

namespace Services;

public class UserService {
    private readonly IRepository _iRepo;

    public UserService(IRepository iRepo){
        _iRepo = iRepo;
    }

    public void CreateAccount(Employee newEmp){
        try{
            _iRepo.AddUser(newEmp);
        }
        catch (Exception) {
            
            Console.WriteLine("Error, Could Not Create Account!");
            throw;
        }
    }

    public Employee VerifyUser(string usernameIn, string passwordIn) {

        List<Employee> userList = _iRepo.GetEveryUser();

        for(int i = 0; i < userList.Count; i++){
            if (userList[i].username.Equals(usernameIn) && userList[i].password.Equals(passwordIn)){
                return userList[i];
            }
        }
        return null;
        
    }

}
