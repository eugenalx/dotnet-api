using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }


    // [HttpGet("GetUsers/{testValue}")]
    // // public IEnumerable<User> GetUsers()
    // public string[] GetTestUsers(string testValue)
    // {
    //     return new string[] { "user1", "user2", testValue };
    // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    // {
    //     // Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //     // TemperatureC = Random.Shared.Next(-20, 55),
    //     // Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    // })
    // .ToArray();
    // }

    [HttpGet("GetUsers")]
    // public IEnumerable<User> GetUsers()
    public IEnumerable<User> GetUsers()
    {
        string sql = @"
            SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
            FROM TutorialAppSchema.Users       
        ";
        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        return users;
        // return new string[] { "user1", "user2" };
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     // Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //     // TemperatureC = Random.Shared.Next(-20, 55),
        //     // Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }

    [HttpGet("GetUsers/{userId}")]
    // public IEnumerable<User> GetUsers()
    public User GetSingleUser(int userId)
    {
        string sql = @"
            SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
            FROM TutorialAppSchema.Users  
                WHERE UserId = "  + userId.ToString();
            
            User user = _dapper.LoadDataSingle<User>(sql);
            return user;
        // return  Users { "user1", "user2", testValue };
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
            // Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            // TemperatureC = Random.Shared.Next(-20, 55),
            // Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }

}
