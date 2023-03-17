using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickShort1
{
    class Program
    {
        /// <summary>
        /// main class
        /// </summary>
        //array of integers to hold values 
        private int[] arr = new int[20];
        private int camp_count = 0;
        private int mov_count = 0;

        //Number of element in array 
        private int n;


        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of element in the array");//Untuk memasukkan angka pada array
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)//angka tidak bisa melebihi 20
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elementd \n");//Jika element yang ada pada array melebihi 20
            }
            Console.WriteLine("\n==========");
            Console.WriteLine("Enter Array Elements");//masukkan array
            Console.WriteLine("\n===================");

            //get array elements 
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }
        //swaps the element at index x with the element at index y
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void q_short(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //Partition the list into two parts;
            //one containing elements less that or equal to pivot
            //Outher conntaining elements greather than pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //Search for an element greater than pivot
                while ((arr [i] <= pivot ) && (i >=low))
                {
                    i++;
                    camp_count++;
                }
                camp_count++;

                //Search for an element ;ess than or equal to pivot 
                while ((arr[j] < pivot) && (j >= low))
                {
                    j++;
                    camp_count++;
                }
                camp_count++;

                if ( i < j) // if the greater element is on the left of the element
                {
                    //swap the element at index i whit the element at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            //j now constaint the index of the last element in the sorted list
            
            if (low < j)
            {
                //move the pivot to its correct posisition in the list
                swap(low, j);
                mov_count++;
            }
            //sort the list on the left of pivot using quick short
            q_short(low, j - 1);

            //sort the list on the right of pivot using quick short
            q_short(j + 1, high);
        }
        void display()
        {
            Console.WriteLine("\n===================");
            Console.WriteLine("Sorted array elements");
            Console.WriteLine("=====================");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparassion" );
            Console.WriteLine("\nNumber of data movements"); 
        }
        int getSize()
        {
            return n;
        }
        static void Main(string[] args)
        {
            //Declarating the object of the class
            Program myList = new Program();
            //Accept array elements 
            myList.input();
            //Calling the sorting function
            //Frist call to Quidk sort Algorithm
            myList.q_short(0, myList.getSize() - 1);
            //Display sorted array 
            myList.display();
            // to exit from the console
            Console.WriteLine("\n\nPress Enter To Exit");
            Console.Read();
        }
    }
}
