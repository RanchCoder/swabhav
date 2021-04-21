using EFCoreConsoleApp.DBContext;
using EFCoreConsoleApp.Model;
using System;
using System.Linq;

namespace EFCoreConsoleApp
{
    class Program
    {
        CollegeDBContext studentDBContext = new CollegeDBContext();
        private const bool OPERATION_SUCCESS = true;
        private const bool OPERATION_FAILURE = false;

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.AddStudent();
            obj.UpdateStudent();
            obj.DeleteStudent();

            Console.ReadLine();
        }

        public void AddStudent()
        {

            Console.Write("\nStudent Name : " );
            string name = Console.ReadLine();


            Console.Write("\nStudent address : ");
            string address = Console.ReadLine();


            Console.Write("\nStudent contact number : ");
            string phoneNo = Console.ReadLine();
            int contactNumber;
            int.TryParse(phoneNo,out contactNumber);

            studentDBContext.Students.Add(new Student { Name = name, Address = address, PhoneNo = contactNumber });
            Save();

        }


        public bool UpdateStudent()
        {
            Console.WriteLine("\nUpdate Student Record");
            try
            {
                Console.Write("\nStudent Id : ");
                string userInputForID = Console.ReadLine();
                int studentId;
                int.TryParse(userInputForID, out studentId);

                foreach (var student in studentDBContext.Students.Where(s => s.Id == studentId))
                {
                    student.Name = "Updated_Name";
                    student.PhoneNo = 449202;
                    student.Address = "kagasthan";
                }
                Save();
                return OPERATION_SUCCESS;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }
            

        }


        public bool DeleteStudent()
        {

            Console.WriteLine("\nDelete Student Record");
            try
            {
                Console.Write("\nEnter Student Id for which you wish to delete record : ");
                string userInputForID = Console.ReadLine();
                int studentId;
                int.TryParse(userInputForID, out studentId);
                if (IsStudentIdValid(studentId))
                {
                    var studentToDelete = studentDBContext.Students.Where(s => s.Id == studentId).FirstOrDefault();
                    studentDBContext.Students.Remove(studentToDelete);
                    Save();
                    return OPERATION_SUCCESS;

                }
                else
                {
                    return OPERATION_FAILURE;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OPERATION_FAILURE;
            }

        }


        public bool IsStudentIdValid(int studentId) {

            return studentDBContext.Students.Any(student=>student.Id == studentId);


        }

        public void Save()
        {
            studentDBContext.SaveChanges();
        }

       
    }
}
