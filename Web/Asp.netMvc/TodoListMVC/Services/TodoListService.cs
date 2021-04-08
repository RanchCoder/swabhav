using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoListMVC.Models;
using TodoListMVC.Repository;

namespace TodoListMVC.Services
{
    public class TodoListService
    {
        protected TodoListRepository todoListRepository;
        public TodoListService()
        {
            todoListRepository = new TodoListRepository();
        }

        public bool AddNewSubTodo(string subTodoName, int todoId)
        {
            return todoListRepository.AddNewSubTodo(subTodoName,todoId);
        }

       

        public bool AddATodo(TodoList todo,string userName)
        {
            
            return todoListRepository.AddATodo(todo,userName);
        }

        public List<SubTodoList> GetSubTodoLists(int todoId)
        {
           return todoListRepository.GetSubTodoLists(todoId);
        }

        public SubTodoList GetSubTodoItemById(int id)
        {
            return todoListRepository.GetSubTodoItemById(id);
        }

        public bool EditSubTodoList(SubTodoList subTodoListItem)
        {
            return todoListRepository.EditSubTodoList(subTodoListItem);
        }
        public TodoList GetTodoById(int id)
        {
            return todoListRepository.GetTodoById(id);
        }

        public List<TodoList> GetTodoLists(string username)
        {
            return todoListRepository.GetTodoLists(username);
        }

        public bool InitializeTodoList()
        {
           return todoListRepository.InitializeTodoList();
        }

        public bool IsUserNameAvailable(string username)
        {
            return todoListRepository.IsUserNameAvailable(username);
        }

        public bool RegisterUser(Registration registration)
        {
            return todoListRepository.RegisterUser(registration);
        }

        public bool IsValidUser(Registration registration)
        {
            return todoListRepository.IsValidUser(registration);
        }
    }
}