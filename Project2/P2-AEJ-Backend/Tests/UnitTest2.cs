using DataAccess;
using Models;
using Services;
using Moq;
namespace Tests;

public class UnitTest2{
    


    [Fact]
    public void TestFullItem(){
        Item item = new Item(2, "name", 10, 10, "url");

        item.Id = 22;
        item.Name = "newName";
        item.Balance = 100;
        item.UnitPrice = 200;
        item.Url = "newUrl";

        Assert.Equal(22, item.Id);
        Assert.Equal("newName", item.Name);
        Assert.Equal(100, item.Balance);
        Assert.Equal(200, item.UnitPrice);
        Assert.Equal("newUrl", item.Url);

    }
    [Fact]
    public void TestFullMisc(){
        Misc testMisc = new Misc(30, 100, 10);

        testMisc.ListingId = 1200;
        testMisc.Quantity = 200;
        testMisc.BuyerId = 2;

        Assert.Equal(120, testMisc.ListingId);
        Assert.Equal(200, testMisc.Quantity);
        Assert.Equal(10, testMisc.BuyerId);
    }

    [Fact]

    publice void TestFullSellInfo(){
        Sellinfo si = new Sellinfo(2,20,5,2000);

        si.ItemId = 3;
        si.Quantity = 10;
        si.SellerId = 2;
        si.Price = 2500;

        Assert.Equal(3, si.ItemId);
        Assert.Equal(10, si.Quantity);
        Assert.Equal(2, si.SellerId);
        Assert.Equal(2500, si.Price);
    }

    [Fact]
    public void TestGetUsers(){

        var mockRepo = new Mock<IRepository>();
        var _service = new UserServices(mockRepo.Object);

        Assert.NotNull(_service.GetUsers());

        
    }

    [Fact]
    public void TestUserLogin(){

        var mockRepo = new Mock<IRepository>();
        var _service = new UserServices(mockRepo.Object);
        User newUser = new User();
        newUser.Username = "userFake";
        newUser.Password = "passFake"
        Assert.False(_service.UserLogin(newUser));

        
    }

    [Fact]
    public void TestGetMarketItems(){

        var mockRepo = new Mock<IRepository>();
        var _service = new UserServices(mockRepo.Object);

        Assert.NotNull(_service.GetMarketplaceItems());

    }

        [Fact]
    public void TestUserLogin(){

        var mockRepo = new Mock<IRepository>();
        var _service = new UserServices(mockRepo.Object);
        User newUser = new User();
        newUser.Username = "bing";
        newUser.FirstName = "test";
        newUser.LastName = "user";
        newUser.Id = 15;
        newUser.Password = "bong";
        wallet = 1000;

        User act = _service.GetUserByUsername("bing");
        
        Assert.Equal(act, newUser);

        
    }


}