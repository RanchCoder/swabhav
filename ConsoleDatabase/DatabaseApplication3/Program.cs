using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=.\\sqlexpress; Database=swabhav;User Id=sa;Password=root;";
            SqlConnection connection_obj = new SqlConnection(connectionString);
            SqlCommand command_obj;
            SqlDataReader datareader;
            try
            {
                connection_obj.Open();
                if (connection_obj.State == ConnectionState.Closed)
                {
                    connection_obj.Open();
                }
                string query = "select * from EMP";
                string query2 = "select max(sal) as max_salary from EMP";
                string query3 = "select ename,dname from DEPT join EMP on EMP.DEPTNO = DEPT.DEPTNO";
                string query4 = "select ename,job,hiredate,sal,dname,loc from EMP LEFT OUTER JOIN DEPT on EMP.DEPTNO = DEPT.DEPTNO";
                string query5 = "select emp.deptno,dept.dname from emp inner join dept on emp.deptno = dept.deptno group by emp.deptno,dept.dname";
                string query6 = "select count(*) as employee_by_department, dept.dname from emp LEFT OUTER JOIN dept on emp.deptno = dept.deptno group by emp.deptno,dept.dname";
                command_obj = new SqlCommand(query6, connection_obj);
               
                datareader = command_obj.ExecuteReader();

                while (datareader.Read())
                {
                    //Console.WriteLine($"employee name : {datareader["ename"]} -- employee salary : {datareader["sal"]}");
                    //Console.WriteLine($"Employee Name  : {datareader["ename"]} | JOB TYPE : {datareader["job"]} | " +
                    //    $"HIREDATE of employee : {datareader["hiredate"]} | salary : {datareader["sal"]} " +
                    //    $"Department name : {datareader["dname"]} | " +
                    //    $"location  : { datareader["loc"]}");
                    //Console.WriteLine($"DEPARTMENT NUMBER : {datareader["deptno"]} | DEPARTMENT NAME : {datareader["dname"]}");
                    Console.WriteLine($"DEPARTMENT NAME  : {datareader["dname"]}   |   EMPLOYEE COUNT : {datareader["employee_by_department"]} ");

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection_obj.Close();
            }
            Console.ReadLine();
        }
    }
}
