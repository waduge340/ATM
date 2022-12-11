using System;
using System.IO;

namespace ATM
{

    class ATM
    {
        static void Main(string[] args)
        {
            string[,] cardDetails = { { "1234567890", "1234" }, { "2468101214", "1793" }, { "3691215182", "7539" }, { "4812162024", "9517" } };
            string pinNumber = ""; 
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("");

            Console.WriteLine("Please Enter the Card Number: ");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("Card Number is: " + cardNumber);

            ATM obj = new ATM();

            //obj.searchCard(cardNumber, cardDetails);

            if (!(obj.searchCard(cardNumber, cardDetails)))
            {
                Console.WriteLine("Please Enter a valid card number");
                Console.WriteLine("Good Bye!");
            }
            else
            {
                Console.WriteLine("Card Number is Valid");
                Console.WriteLine("Please Enter the PIN: ");
                pinNumber = Console.ReadLine();
                Console.WriteLine("PIN is: " + pinNumber);
                obj.validPIN(obj.pin(cardNumber, cardDetails), pinNumber);
            }
        }

        

        public bool searchCard(string cardNumber, string[,] cardDetails) {

            //string matchedCard;
            bool isCardValid = false;

            for (int i = 0; i < cardDetails.GetLength(0); i++)
            {
                if (cardDetails[i, 0] != cardNumber)
                {
                    isCardValid = false;
                    continue;
                }
                else 
                {
                    isCardValid = true;
                    break;
                }
            }
            return isCardValid;
        }

        public string pin(string cardNumber, string[,] cardDetails)
        {
            string pin = "";
            for (int i = 0; i < cardDetails.GetLength(0); i++)
            {
                if (cardDetails[i, 0] != cardNumber)
                {
                    continue;
                }
                else
                {
                    pin = cardDetails[i, 1];
                    //Console.WriteLine("Correct PIN is: "+pin);
                    break;
                }
            }
            return pin;
        }

        public void validPIN(string pinNumber, string validPIN)
        {
            
            if (pinNumber == validPIN) {
                Console.WriteLine("PIN is Valid");
            }
            else
            {
                Console.WriteLine("Invalid PIN. Access Denied!");
            }
        }


        

        /*public bool matchPIN(string path, string cardNumber, string pinNumber)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }
            }
            
    }
}

