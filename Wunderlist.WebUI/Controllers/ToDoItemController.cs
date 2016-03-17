﻿using System.Linq;
using System.Web.Mvc;
using Wunderlist.Services.Interfaces.Services;

namespace Wunderlist.WebUI.Controllers
{
    [Authorize]
    public class ToDoItemController : Controller
    {
        private enum Status
        {
            Wait = 1,
            Completed = 2
        };

        private readonly IToDoListService _toDoListService;
        private readonly IUserService _userService;
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoItemController(IToDoListService toDoListService, IUserService userService, IToDoTaskService toDoTaskService)
        {
            _toDoListService = toDoListService;
            _userService = userService;
            _toDoTaskService = toDoTaskService;
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult GetToDoItems(string listName)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;
            var toDoList = _toDoListService
                .GetAllToDoListEntitiesById(userId)
                .FirstOrDefault(c => c.Name == listName);

            if (toDoList != null)
            {
                var tasks = _toDoTaskService.GetAllTasksByListIdAndStatusId(toDoList.Id, (int)Status.Wait).ToList();
                return Json(tasks, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult AddToDoItem(string name, string listname)
        {
            var userEmail = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserEntity(userEmail).Id;

            var toDoListServiceEntity = _toDoListService
                .GetAllToDoListEntitiesById(userId)
                .FirstOrDefault(c => c.Name == listname);

            if (toDoListServiceEntity == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var toDoListId = toDoListServiceEntity.Id;
            _toDoTaskService.Create(name, toDoListId);

            return GetToDoItems(listname);
        }

        [System.Web.Mvc.HttpPut]
        public JsonResult DeleteToDoItem(int taskId, string listname)
        {
            _toDoTaskService.Delete(taskId);
            return GetToDoItems(listname);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult RenameToDoItem(int taskItemId, string taskname, string listname)
        {
            var currentTask = _toDoTaskService.GetTaskById(taskItemId);
            _toDoTaskService.Update(taskItemId, taskname, currentTask.TaskStatusId);
            return GetToDoItems(listname);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult ChangeTaskStatus(int taskId, bool status, int listId)
        {
            var currentToDoList = _toDoListService.GetById(listId);
            var currentTask = _toDoTaskService.GetTaskById(taskId);
            var statusId = (status) ? Status.Completed : Status.Wait;
            _toDoTaskService.Update(taskId, currentTask.Name, (int)statusId);
            return GetToDoItems(currentToDoList.Name);
        }


        [System.Web.Mvc.HttpPost]
        public JsonResult GetCompletedToDoItems(int listId)
        {
            var currentToDoList = _toDoListService.GetById(listId);
            var toDoItems = _toDoTaskService.GetAllTasksByListIdAndStatusId(currentToDoList.Id, (int)Status.Completed);
            if (toDoItems == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            return Json(toDoItems, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddDueDateAndNote(int taskId, string note, int listId)
        {
            _toDoTaskService.SaveDueDate(taskId);
            _toDoTaskService.SaveNote(taskId, note);
            var currentToDoList = _toDoListService.GetById(listId);
            return GetToDoItems(currentToDoList.Name);
        }
        
        [System.Web.Mvc.HttpPost]
        public JsonResult GetToDoItemNote(int toDoItemId)
        {
            var task = _toDoTaskService.GetTaskById(toDoItemId);
            return Json(task, JsonRequestBehavior.AllowGet);
        }
    }
}