using ClassroomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ClassroomApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly ILogger<UserDataController> logger;
        private readonly MySqlDbContext context;
        private readonly IConfiguration config;

        public UserDataController(ILogger<UserDataController> logger, MySqlDbContext context, IConfiguration config)
        {
            this.logger = logger;
            this.context = context;
            this.config = config;
        }

        [Route(nameof(Add))]
        [HttpPost]
        public object Add(UserData userData)
        {
            context.UserData.Add(userData);
            context.SaveChanges();

            return new
            {
                Size = context.UserData.Count(),
                State = "done"
            };
        }

        [Route(nameof(GetClasses))]
        [HttpGet]
        public IEnumerable<string> GetClasses(string username)
        {
            return context.UserData
                .Where(data => data.Username == username)
                .Select(data => data.ClassName);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<UserData> Get()
        {
            return context.UserData;
        }

        [Route(nameof(Delete))]
        [HttpDelete]
        public void Delete(UserData userData)
        {
            context.Remove(context.UserData.Single(data => data.Username == userData.Username && data.ClassName == userData.ClassName));
            context.SaveChanges();
        }
    }
}
