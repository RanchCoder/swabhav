using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListAssignment.Model;

namespace TodoListAssignment
{
    class Program
    {
        public const int ADD = 1, VIEW = 2, EDIT = 3, EXIT = 4;
        public static List<TodoList> todoItemList = new List<TodoList>();
        public static int id = 1;
        static void Main(string[] args)
        {

            InitializeGame();
            Console.ReadLine();
        }

        public static void InitializeGame()
        {
            Console.WriteLine($"------TODO LIST--------\n");
            Console.WriteLine($"***********NOW MANAGE YOUR DAILY TASKS************");
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("Make a Choice");
                Console.WriteLine("\n1.Add a Task");
                Console.WriteLine("\n2.View all Task");
                Console.WriteLine("\n3.Change status of Task");
                Console.WriteLine("\n4.Exit");

                Console.Write("\nYour choice :: ");
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case ADD:
                        AddATask();
                        break;
                    case VIEW:
                        ViewTask();
                        break;
                    case EDIT:
                        EditATask();
                        break;
                    case EXIT:
                        isPlaying = false;
                        break;

                }
            }
        }

        private static void EditATask()
        {
            ViewTask();
            Console.Write($"\nEnter task id whose data you wish to edit : ");
            int statusId = Int32.Parse(Console.ReadLine());

            Console.Write($"Todo Name : ");
            string name = Console.ReadLine();
            Console.WriteLine($"Is Todo Work Complete : (Enter Yes/No)");
            string dataEntered = Console.ReadLine();
            bool status;
            if(dataEntered.ToLower() == "yes" || dataEntered.ToLower() == "y")
            {
                status = true;
            }
            else
            {
                status = false;
            }

            foreach(var todoItem in todoItemList.Where(x=>x.Id == statusId))
            {
                todoItem.Name = name;
                todoItem.Status = status;

            }
        }

        private static void ViewTask()
        {
            Console.WriteLine($"\n\nShowing all tasks");
            Console.WriteLine($"\n\n ID | TODO NAME | DATE | STATUS");
            foreach (var todoItem in todoItemList)
            {
                if(todoItem.Status == true)
                {
                    Console.WriteLine($"{todoItem.Id} | {todoItem.Name} | {todoItem.DateTime.Day} / {todoItem.DateTime.Month} / {todoItem.DateTime.Year} | Complete");

                }
                if(todoItem.Status == false)
                {
                    Console.WriteLine($"{todoItem.Id} | {todoItem.Name} | {todoItem.DateTime.Day} / {todoItem.DateTime.Month} / {todoItem.DateTime.Year} | Pending");

                }
            }
        }

        private static void AddATask()
        {
            Console.WriteLine($"\n\nEnter your Todo Details");

            Console.Write($"\nTodo name : ");
            string todoName = Console.ReadLine();

            TodoList todoList = new TodoList();
            todoList.Id = id;
            todoList.Name = todoName;
            todoList.DateTime = DateTime.Now;
            todoList.Status = false;
            id += 1;
            todoItemList.Add(todoList);

        }
    }

}
