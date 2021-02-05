using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_App.model
{
    class Candidate
    {
        private int id;
        private string name;
        private int age;
        private string creditPoint;
        const string IS_YOUNGER = "younger_in_age";
        const string IS_OLDER = "older_in_age";
        const string IS_OF_SAME_AGE = "equal_in_age";
        const string HAVE_SAME_CREDIT_SCORES = "same_credit_score";
        const string LESSER_CREDIT_SCORE = "lesser_credit_score";
        const string GREATER_CREDIT_SCORE = "greater_credit_score";

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string CreditPoint { get => creditPoint; set => creditPoint = value; }

        public Candidate(int id, string name,int age,string creditPoint)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.creditPoint = creditPoint;
        }

        public Candidate(int id,string name,int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.creditPoint = "F";
        }



        

        public string whoIsOlderInAge(int ageToBeCompared,Candidate c)
        {
            if(this.age < ageToBeCompared)
            {
                return IS_YOUNGER;
               
            }
            else if(this.age > ageToBeCompared)
            {
                return IS_OLDER;
               
            }
            else
            {
                return IS_OF_SAME_AGE;
               
            }
        }

        public string whoIsBetter(string creditPointToCompare,Candidate c2)
        {
           int returnedValue =  string.Compare(this.creditPoint,creditPointToCompare);
            if (returnedValue == 0)
            {
                return HAVE_SAME_CREDIT_SCORES;
               
            }
            else if (returnedValue < 0)
            {
                return GREATER_CREDIT_SCORE;

            }
            else
            {
                return LESSER_CREDIT_SCORE;
                
            }

        }


    }
}
