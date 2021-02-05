using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_App.model;

namespace Candidate_App
{
    class Program
    {
        const string PRINT_AGE = "print_age";
        const string PRINT_CREDITSCORE = "print_creditScore";
        public static void PrintComparisonResult(Candidate c1,Candidate c2,ref string comparisonResult,string printParamter)
        {
            if(printParamter.Equals(PRINT_AGE))
            {
                if (comparisonResult == "same_credit_score")
                {
                    Console.WriteLine($"{c1.Name} with grade : {c1.CreditPoint} has performed same as {c2.Name} whose grade is : {c2.CreditPoint}");
                }
                else if (comparisonResult == "greater_credit_score")
                {

                    Console.WriteLine($"{c1.Name} with grade : {c1.CreditPoint} has performed better than {c2.Name} whose grade is : {c2.CreditPoint}");
                }
                else
                {
                    Console.WriteLine($"{c2.Name} with grade : {c2.CreditPoint} has performed better than {c1.Name} whose grade is : {c1.CreditPoint}");
                }
                return;
            }

            if(printParamter.Equals(PRINT_CREDITSCORE))
            {
                if (comparisonResult == "younger_in_age")
                {
                    Console.WriteLine($"{c1.Name} is younger than {c2.Name}.");
                }
                else if (comparisonResult == "older_in_age")
                {
                    Console.WriteLine($"{c1.Name} is older than {c2.Name}.");
                }
                else
                {
                    Console.WriteLine($"{c1.Name} and {c2.Name} have the same age.");
                }

            }
            
        }
       

        static void Main(string[] args)
        {
            Candidate c1 = new Candidate(1,"Vishal",21,"A");
            Candidate c2 = new Candidate(2, "Prem", 22, "B");


            Console.WriteLine();
            string creditScoreComparisonResult = c1.whoIsBetter(c2.CreditPoint,c2);
            PrintComparisonResult(c1,c2,ref creditScoreComparisonResult,PRINT_AGE);
             

            string ageComparisonResult = c1.whoIsOlderInAge(c2.Age,c2);
            
            PrintComparisonResult(c1,c2,ref ageComparisonResult,PRINT_CREDITSCORE);
           


            Console.ReadLine();
        }

        
    }
}
