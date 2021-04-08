using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListMVC.Models;

namespace TodoListMVC.Repository
{
    interface ITodoListRepository
    {

        List<TodoList> GetTodoLists(string username);
        bool AddATodo(TodoList todo,string userName);
        TodoList GetTodoById(int id);
        bool InitializeTodoList();
        bool DeleteTodo(int todoId);
        bool AddNewSubTodo(string subTodoName,int todoId);
        List<SubTodoList> GetSubTodoLists(int idTodo);
        SubTodoList GetSubTodoItemById(int id);
        bool EditSubTodoList(SubTodoList subTodoListItem);
        bool DeleteSubTodoItem(int subTodoId);

        bool IsUserNameAvailable(string username);
        bool RegisterUser(Registration registration);
        bool IsValidUser(Registration registration);
        
    }
}
