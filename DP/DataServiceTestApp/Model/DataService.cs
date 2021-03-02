using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceTestApp.Model
{
    class DataService
    {
        private static DataService bucket;
        
        private DataService()
        {
            Console.WriteLine("Data service created");
        }

        public static DataService GetInstance()
        {
            if(bucket == null)
            {
                bucket = new DataService();
            }
            return bucket;
        }

        public void ProcessData()
        {
            Console.WriteLine("hash code of current data service " + bucket.GetHashCode());
        }


    }
}
