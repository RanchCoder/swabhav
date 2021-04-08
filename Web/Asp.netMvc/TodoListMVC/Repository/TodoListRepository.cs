using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoListMVC.DatabaseContext;
using TodoListMVC.Models;

namespace TodoListMVC.Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        public const int VALID_USER_COUNT = 1,USERNAME_AVAILABLE = 0;
        public const bool PENDING = false,
                          COMPLETED = true,
                          OPERATION_SUCCESSFUL = true,
                          OPERATION_FAILURE = false;
        private TodoDBContext _todoDBContext;
        public TodoListRepository()
        {
            _todoDBContext = new TodoDBContext();
        }

        public bool AddATodo(TodoList todo, string userName)
        {
            try
            {
                Registration registeredUser = _todoDBContext.Registrations.Where(user => user.UserName == userName).FirstOrDefault();
                todo.Registration = registeredUser;
                _todoDBContext.TodoLists.Add(todo);
                _todoDBContext.SaveChanges();
                return OPERATION_SUCCESSFUL;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }
        }        

        public List<TodoList> GetTodoLists(string username)
        {
            Registration userProfile = _todoDBContext.Registrations.Where(user => user.UserName == username).FirstOrDefault();

            return _todoDBContext.TodoLists.Where(todo => todo.Registration.Id == userProfile.Id).ToList();
        }

        public TodoList GetTodoById(int id)
        {
            return _todoDBContext.TodoLists.Where(todo => todo.Id == id).FirstOrDefault();
        }


        public bool AddNewSubTodo(string subTodoName, int todoId)
        {
            try
            {
                SubTodoList subTodoItem = new SubTodoList();
                subTodoItem.SubTodoDate = DateTime.Now;
                subTodoItem.SubTodoName = subTodoName;
                subTodoItem.SubTodoStatus = PENDING;
                subTodoItem.TodoList = _todoDBContext.TodoLists.Where(todo => todo.Id == todoId).FirstOrDefault();
                _todoDBContext.SubTodoLists.Add(subTodoItem);
                _todoDBContext.SaveChanges();
                return OPERATION_SUCCESSFUL;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }
        }

        public bool EditSubTodoList(SubTodoList subTodoListItem)
        {
            try
            {
                foreach (var subTodo in _todoDBContext.SubTodoLists.Where(item => item.Id == subTodoListItem.Id))
                {

                    subTodo.SubTodoStatus = subTodoListItem.SubTodoStatus;
                }
                _todoDBContext.SaveChanges();
                return OPERATION_SUCCESSFUL;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }

        }

        public List<SubTodoList> GetSubTodoLists(int todoId)
        {
            return _todoDBContext.SubTodoLists.Where(subTodo => subTodo.TodoList.Id == todoId).ToList();
        }

        public SubTodoList GetSubTodoItemById(int id)
        {
            return _todoDBContext.SubTodoLists.Where(subTodo => subTodo.Id == id).FirstOrDefault();
        }               

        
        public bool InitializeTodoList()
        {
            TodoList todo1 = new TodoList() { Name = "Reading"};

            Registration user1 = new Registration() { UserName = "VishalMac", Password = "abcd"};

            SubTodoList subTodo1 = new SubTodoList() { SubTodoName = "Murder on the links", SubTodoDate = DateTime.Now, SubTodoStatus = false };

            SubTodoList subTodo2 = new SubTodoList() { SubTodoName = "Thinking fast and slow", SubTodoDate = DateTime.Now, SubTodoStatus = false };

            try
            {
                subTodo1.TodoList = todo1;
                subTodo2.TodoList = todo1;
                
                todo1.SubTodoLists.Add(subTodo1);
                todo1.SubTodoLists.Add(subTodo2);


                todo1.Registration = user1;
                user1.UserTodoLists.Add(todo1);

                _todoDBContext.TodoLists.Add(todo1);
                _todoDBContext.Registrations.Add(user1);
                _todoDBContext.SaveChanges();
                return OPERATION_SUCCESSFUL;


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }
        }

        

        public bool RegisterUser(Registration registration)
        {
            try
            {
                _todoDBContext.Registrations.Add(registration);
                _todoDBContext.SaveChanges();
                return OPERATION_SUCCESSFUL;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }        
        }

        public bool IsUserNameAvailable(string userName)
        {
            int userNameCountInDB = _todoDBContext.Registrations.Where(registeredUser => registeredUser.UserName == userName).Count();
            return userNameCountInDB == USERNAME_AVAILABLE;
        }

        public bool IsValidUser(Registration registration)
        {
            try
            {
                int userCount = _todoDBContext.Registrations.Where(user=>user.UserName == registration.UserName && user.Password == registration.Password).Count();
                return userCount == VALID_USER_COUNT;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }
        }

    }
}