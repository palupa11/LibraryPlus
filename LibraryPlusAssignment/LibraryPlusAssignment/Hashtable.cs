using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    public class Hashtable
    {
        private int[] table = new int[1000];
        private int key;

        //Properties 

        public int Key { get; set; }


        // We need a key, table (array)

        //Methods
        //

        //public void Insert(int key)
        //{


        //}

        //public void Insert(string key)
        //{
        //    int sum = 0;
        //    foreach (char c in key)
        //    {
        //        sum = sum + (int)c;
        //    }

        //    int index = DivisionHashing(sum);
        //    table[index]


        //}



        public int DivisionHashing(int sum)
        {
            int M = 101;
            int modulus = sum % M;
            Console.WriteLine("This is the sum" + sum);
            Console.WriteLine("This is mod" + modulus);
            return modulus;

        }

        //Insert, search, delete

    }
}
