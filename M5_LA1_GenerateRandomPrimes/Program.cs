using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_LA1_GenerateRandomPrimes
{

    //Learning Activity 1: Generate Random Primes
    //Create a classes with overloaded methods to represent a Prime Generator.
    //1.Create a method to determine if a number is a prime, and four overloaded methods to generate primes.
    //2.Method without a parameter should generate and display a random prime, method with one integer parameter n will generate and display n random primes,
        //method with two integer parameters (a, b; a<=b) will generate all primes in the range(a, b), and method with three integer parameters(c, a, b; c>=1, a<=b)
        //will generate and display the first c primes(if exists) in the range(a, b).
    //3.Complete all the incomplete methods from the class. And do not alter the Program class.

    class GeneratePrimes
    {
        Random r;
        public GeneratePrimes()
        {
             r = new Random();
        }
        private bool IsPrime(int n)
        {
            //ToDo
            int i;
            if (n <= 1) return false;  //1 is not a prime
            for (i = 2; i <= Math.Sqrt(n); i++)        //can also use  i <= n/2;  
            {
                if (n % i == 0) return false;       //is not a prime
                
            }
            return true;                   //is a prime
        }
        public void Prime()   //be able to display random Prime renge- 2-99
        {
            //ToDo
            int val;
            Console.Write("Random numbers generated: ");
            do
            {
             val = r.Next(1, 1000);         //generate a random value
             Console.Write(" " + val);        //check

            }while(!IsPrime(val));  //everytime you check if it si Prime as long as it's not Prime keep - if Prime then loop is false

            Console.WriteLine("\nFirst Random Prime: " + val);
        }
        public void Prime(int n)  //can have int -one parameter //display n random prime numbers  //to support output format we need new code 
        {
            //ToDo
            int val;
            int i;
            Console.Write("The first, " + n+ " Prime numbers generated: ");
            for (i = 0; i < n; i++)
            {
                do
                {
                    val = r.Next(1, 1000);         //generate a random value
                    //Console.Write(" " + val);        //check

                } while (!IsPrime(val));  //everytime you check if it si Prime as long as it's not Prime keep - if Prime then loop is false
                Console.Write(val + " ");
            }
            Console.WriteLine();
             
        }
    
        /*public void Prime(double n)  //can have both  double- one parameter- just an example
        {
            //ToDo
        }*/
        public void Prime(int a, int b)   //generate and display all primes from range a-b
        {
            //ToDo
            
            int i;
            Console.WriteLine("All Primes in the range: " +a+ " to " +b+".");
            for (i = a; i < b; i++)                 //initialise with a and finish with b
            {
                if (IsPrime(i))
                {
                   Console.Write(i + " "); 
                    
                }
            }
            Console.WriteLine();
        }
        public void Prime(int c, int a, int b)  //c number of primes in the range a-b
        {
            //ToDo
            int i;
            Console.WriteLine("The first: " +c+ " Primes in the range: " + a + " to " + b + ".");
            for (i = a; i < b; i++)                 //initialise with a and finish with b
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                    c--;                            //everytime you print the count decrement c- until it reaches zero to count
                    
                }
                if (c == 0) break;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)   //do not modify any main method  //command is 
        {
            int val, a, b, c;
            var p = new GeneratePrimes();
            string command = "";
            while (command != "exit")
            {
                Console.Clear();
                Console.WriteLine("Please enter a command: ");
                Console.WriteLine("Example: ");
                Console.WriteLine("To generate a random prime: prime");
                Console.WriteLine("To generate 5 random primes: prime 5");
                Console.WriteLine("To generate all primes in the range (10 to 20): prime 10 20");
                Console.WriteLine("To generate first 5 primes in the range (10 to 100): prime 5 10 100");
                Console.WriteLine("To exit from the program: exit");

                command = Console.ReadLine();
                var cmdArgs = command.Split();
                if (cmdArgs.Length == 0)
                    continue;                               //how does continue work?
                else if (cmdArgs[0] == "exit") return;   //if command argument is exit -return?
                else if (cmdArgs.Length == 1)               //prime not followed by anything 
                {
                    if (cmdArgs[0] == "prime")              //
                    {
                        p.Prime();
                    }
                    else continue;
                }
                else if (cmdArgs.Length == 2)
                {
                    if (cmdArgs[0] == "prime")
                    {
                        val = int.Parse(cmdArgs[1]);
                        p.Prime(val);
                    }
                    else continue;
                }
                else if (cmdArgs.Length == 3)
                {
                    if (cmdArgs[0] == "prime")
                    {
                        a = int.Parse(cmdArgs[1]);
                        b = int.Parse(cmdArgs[2]);
                        p.Prime(a, b);
                    }
                    else continue;
                }
                else if (cmdArgs.Length == 4)
                {
                    if (cmdArgs[0] == "prime")
                    {
                        c = int.Parse(cmdArgs[1]);
                        a = int.Parse(cmdArgs[2]);
                        b = int.Parse(cmdArgs[3]);
                        p.Prime(c, a, b);
                    }
                    else continue;
                }
                else
                {
                    Console.WriteLine("\nUnknown Command!. Please enter command in proper format.");
                }

                Console.ReadKey();
            }
        }
    }
}