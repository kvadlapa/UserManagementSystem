using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Models;

namespace UserManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Controller code to manage User entities will go here
        static private List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PasswordHash = "hashed_password_123",
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PasswordHash = "hashed_password_456",
                Role = "User"
            }
        };

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            // C# Lambda expression to find user by Id
            var user = users.Find(u => (u.Id == id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            // Simulate adding the user to the database
            users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

    }

}
   