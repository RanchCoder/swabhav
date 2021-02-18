using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_App.model;

namespace College_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //specifying college detials
            CollegeSpecification specificationsForSiesCollge =
                new CollegeSpecification("SIES college of arts science and commerce",
                                         "Mumbai",
                                         "Maharastra",
                                         "sion",
                                         400022,
                                         true,
                                         true,
                                         true,
                                         true,
                                         true,
                                         true,
                                         true);

            

            //creating individual student
            Student student_1 = new Student("vishal",
                                            "singh",
                                            "sion",
                                            "Mumbai",
                                            "Maharastra",
                                            "Science",
                                            101,
                                            "FYJC SCIENCE",
                                            "A",
                                            SubjectsForStreamAndSubStream.fybsc_compSci_subjects
                                            );

            //creating individual student
            Student student_2 = new Student("Ram",
                                            "singh",
                                            "sion",
                                            "Mumbai",
                                            "Maharastra",
                                            "Science",
                                            102,
                                            "FYJC COMMERCE",
                                            "B",
                                            SubjectsForStreamAndSubStream.fybsc_compSci_subjects
                                            );

            SortedSet<Student> listOfStudent = new SortedSet<Student>();
            listOfStudent.Add(student_1);
            listOfStudent.Add(student_2);
            College siesCollege = new College(specificationsForSiesCollge,listOfStudent);

            PrintCollegeDetails(siesCollege);
           
            Console.ReadLine();
        }

        public static void PrintCollegeDetails(College collegeInstance)
        {
            CollegeSpecification collegeSpecification = collegeInstance.CollegeSpecification;

            Console.WriteLine($"College Name : {collegeSpecification.NameOfCollege}" +
                              $"\nAddress : {collegeSpecification.LocationOfCollege}, {collegeSpecification.CityOfCollege}, {collegeSpecification.StateOfCollege}" +
                              $"\nPin Code : {collegeSpecification.PostalCodeOfCollege}");

            Console.WriteLine($"\n\n**********List of students studying the College***********");
            SortedSet<Student> listOfStudents = collegeInstance.StudentsList;
            
            foreach(Student student in listOfStudents)
            {
                
                Console.WriteLine($"\n\nStudent Name : {student.FirstNameOfStudent} {student.LastNameOfStudent}" +
                                  $"\nStudent Address : {student.ResidentLocationOfStudent} {student.CityOfStudent}, {student.StateOfStudent}" +
                                  $"\nStream of Student :{student.StreamOfStudent}" +
                                   $"\nSub Stream of Student :{student.SubStream}" +
                                  $"\nStudent Roll Number : {student.RollNumberOfStudent}");
            }

        }
    }
}
