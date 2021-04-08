using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoListMVC.CustomerFilter;
using TodoListMVC.Models;
using TodoListMVC.Services;
using TodoListMVC.ViewModels;

namespace TodoListMVC.Controllers
{
    public class HomeController : Controller
    {
        public TodoListService todoListService = new TodoListService();
        // GET: Home
        
        public HomeController()
        {
            Console.WriteLine("home controller called");
        }

        [AuthorizeAccess]
        public ActionResult Index(string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            return View();
        }

        public ActionResult InitializeTodoList()
        {
            bool isListInitialized = todoListService.InitializeTodoList();
            if (isListInitialized)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [AuthorizeAccess]
        public ActionResult AddTodo(string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            return View();
        }


        [AuthorizeAccess]
        public ActionResult SaveTodo(AddTodoVM todoToAdd)
        {
            string userName = (string)Session["AuthenticUser"];
            bool isTodoAdded = todoListService.AddATodo(new TodoList() { Name= todoToAdd.TodoName},userName);
            if (isTodoAdded)
            {
                return RedirectToAction("AddTodo",new { Message = "Todo Added Successfully"});
            }
            else
            {
                return RedirectToAction("AddTodo", new { Message = "ERROR! something went wrong while adding TODO" });
            }
        }

        [AuthorizeAccess]
        public ActionResult ShowAllTodo(string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            List<TodoListVM> todoList = new List<TodoListVM>();
            string username = (string)Session["AuthenticUser"];
            var todoListFromService = todoListService.GetTodoLists(username);
            foreach(var todoItem in todoListFromService)
            {
                todoList.Add(new TodoListVM() { Id = todoItem.Id, Name = todoItem.Name});

            }
            return View(todoList);
        }

        [AuthorizeAccess]
        public ActionResult DeleteTodo(int todoId)
        {
            bool isTodoDeleted = todoListService.DeleteTodo(todoId);
            if (isTodoDeleted)
            {
                return RedirectToAction("ShowAllTodo",new {Message = "Todo deleted successfully" });
            }
            else
            {
                return RedirectToAction("ShowAllTodo", new { Message = "Cannot delete todo" });
            }
        }

        [AuthorizeAccess]
        public ActionResult ShowSubTodo(int id)
        {
            Console.WriteLine(id.GetType());
            var subTodoList = todoListService.GetSubTodoLists(id);
            List<SubTodoListVM> subTodoListVM = new List<SubTodoListVM>();
            foreach(var item in subTodoList)
            {
                subTodoListVM.Add(new SubTodoListVM() { Id = item.Id, SubTodoName = item.SubTodoName, SubTodoDate = item.SubTodoDate, SubTodoStatus = item.SubTodoStatus });
            }

            return View(subTodoListVM);

        }

        [AuthorizeAccess]
        public ActionResult EditSubTodo(int id)
        {
            var subTodoItem = todoListService.GetSubTodoItemById(id);
            SubTodoListVM subTodoInstance = new SubTodoListVM();
            subTodoInstance.Id = subTodoItem.Id;
            subTodoInstance.SubTodoName = subTodoItem.SubTodoName;
            subTodoInstance.SubTodoDate = subTodoItem.SubTodoDate;
            subTodoInstance.SubTodoStatus = subTodoItem.SubTodoStatus;
            
            return View(subTodoInstance);
        }

        public ActionResult AddSubTodo(int id,string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            AddSubTodoVM addSubTodo = new AddSubTodoVM();
            addSubTodo.TodoListId = id;
            return View(addSubTodo);

        }

        public ActionResult SaveNewSubTodo(AddSubTodoVM toAddSubTodoItem)
        {
            bool isSubTodoAdded = todoListService.AddNewSubTodo(toAddSubTodoItem.SubTodoName,toAddSubTodoItem.TodoListId);
            if (isSubTodoAdded)
            {
                return RedirectToAction("ShowSubTodo",new{id=toAddSubTodoItem.TodoListId});
            }
            else
            {
                return RedirectToAction("AddSubTodo",new {id=toAddSubTodoItem.TodoListId, Message ="Cannot add subTodo Item,Please try again."});
            }
        }

        public ActionResult EditedSubTodoSave(SubTodoListVM subTodoListVM)
        {
            if (ModelState.IsValid)
            {
                SubTodoList subTodoList = new SubTodoList();
                subTodoList.Id = subTodoListVM.Id;
                subTodoList.SubTodoName = subTodoListVM.SubTodoName;
                subTodoList.SubTodoDate = subTodoListVM.SubTodoDate;
                subTodoList.SubTodoStatus = subTodoListVM.SubTodoStatus;

                bool isSubTodoEdited = todoListService.EditSubTodoList(subTodoList);
                if (isSubTodoEdited)
                {
                    return RedirectToAction("Index", new { Message = "Data Updated Successfully" });

                }
                else
                {
                    return RedirectToAction("Error");

                }

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [AuthorizeAccess]
        public ActionResult DeleteSubTodo(int subTodoId)
        {
            bool isSubTodoDeleted = todoListService.DeleteSubTodoItem(subTodoId);
            if (isSubTodoDeleted)
            {
                return RedirectToAction("ShowAllTodo", new { Message = "Sub todo deleted successfully" });
            }
            else
            {
                return RedirectToAction("ShowAllTodo", new { Message = "Cannot delete sub todo" });
            }
        }


        public ActionResult Registration(string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }
            return View();
        }


        public ActionResult Login(string Message)
        {
            if(Message != null)
            {
                ViewBag.Message = Message;
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("AuthenticUser");
            return RedirectToAction("Login",new {Message="Logged out successfully!!!" });
        }

        public ActionResult AuthenticateUser(Registration registredUser)
        {
            bool isUserAuthentic = todoListService.IsValidUser(registredUser);
            if (isUserAuthentic)
            {
                Session["AuthenticUser"] = registredUser.UserName;
                
                return RedirectToAction("Index",new {Message = $"Welcome {Session["AuthenticUser"]}" });

            }
            else
            {
                return RedirectToAction("Login",new { Message="Please make sure you enter correct credentials" });
            }
        }

        public ActionResult RegisterUser(RegistrationVM registrationVM)
        {
            bool isUserNameAvailable = todoListService.IsUserNameAvailable(registrationVM.UserName);
            if (isUserNameAvailable)
            {
                bool isUserRegistered = todoListService.RegisterUser(new Models.Registration() { UserName = registrationVM.UserName,Password = registrationVM.Password});
                if (isUserRegistered)
                {
                    return RedirectToAction("Login",new { Message = "User successfully registered"});
                }
                else
                {
                    return RedirectToAction("Registration",new { Message="user registration unsuccessful"});
                }
            }
            else
            {
                return RedirectToAction("Registration", new { Message = "username already taken" });
            }
        }



        public ActionResult Error()
        {
            return View();
        }
    }
}