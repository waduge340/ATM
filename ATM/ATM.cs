using System;

namespace ATM
{

    class ATM
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("");
            Console.WriteLine("Please Enter the Card Number: ");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("Card Number is: "+cardNumber);

            //Search Card Number in the system

            Console.WriteLine("Please Enter the PIN: ");
            string pinNumber = Console.ReadLine();
            Console.WriteLine("PIN is: " + pinNumber);

            //Check if the PIN is valid

        }
    }
}

