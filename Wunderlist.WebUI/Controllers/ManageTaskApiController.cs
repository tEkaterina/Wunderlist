using System.Collections.Generic;
using System.Web.Http;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;

namespace Wunderlist.WebUI.Controllers
{
    public class ManageTaskApiController : ApiController
    {
        private readonly IUserService _userService;

        public ManageTaskApiController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/ManageTaskController 
        // TODO: edit task = user
        public IEnumerable<UserServiceEntity> GetTasksEntities()
        {
            var tasks = _userService.GetAllUserEntities();
            return tasks;
        }
    }
}
