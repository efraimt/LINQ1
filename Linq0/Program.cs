using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq0
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[] { 10, 12, 5, 9, 10, 87, -15, 3000, 29 };

            //var innerList = new List<int>();
            //foreach (var num1 in numbers)
            //{
            //    if(num1>=0) 
            //        innerList.Add(num1);
            //}

            //Fethc positive numbers
            var query0 = from num1 in numbers
                         where num1 >= 0
                         select num1;

            var query0N = numbers.Where(num1 => num1 >= 0);

            foreach (var item in query0N)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==================================");


            //Fetch 3 first items
            var q2N = numbers.Take(3).ToList();
            var list2 = q2N.ToList();
            //var query1 = from num1 in numbers



            //Fetch all even numbers
            //Define the query
            var query2 = from number in numbers
                         where number % 2 == 0
                         select number;

            //Execute the query
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==================================");

            //Fetch all items of 'numbers' return it * 10
            var query3 = (from number in numbers
                          select number * 10);
            var lst3 = numbers.Select(number => number * 10).ToList();


            var list = query3.ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==================================");
            var query4 = from number in numbers
                         where number % 2 == 0
                         select "Or Ganon";

            //Execution 1
            foreach (var item in query4)
            {
                Console.WriteLine(item);
            }

            //Execution 2
            var listStr = query4.ToList();


            Console.WriteLine("==================================");
            var query5 = (from number in numbers
                         orderby number descending
                         select number).Take(3);
            var q5N = numbers.OrderByDescending(n => n).ToList();
            var arr = query5.ToArray();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
