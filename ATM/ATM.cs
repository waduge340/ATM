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
            string selection;
            int selectionInt;
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("");

            Console.WriteLine("Please Enter the Card Number: ");
            string cardNumber = Console.ReadLine();
            //Console.WriteLine("Card Number is: " + cardNumber);

            ATM obj = new ATM();
            //Console.WriteLine("hhhhhh");
            obj.checkFiles(cardDetails);

            //obj.searchCard(cardNumber, cardDetails);

            if (!(obj.searchCard(cardNumber, cardDetails)))
            {
                Console.WriteLine("Please Enter a valid card number");
                Console.WriteLine("Good Bye!");
            }
            else
            {
                //Console.WriteLine("Card Number is Valid");
                Console.WriteLine("\nPlease Enter the PIN: ");
                pinNumber = Console.ReadLine();
                //Console.WriteLine("PIN is: " + pinNumber);
                if (!(obj.validPIN(obj.pin(cardNumber, cardDetails), pinNumber)))
                {
                    Console.WriteLine("Invalid PIN. Access Denied!");
                }
                else
                {
                    Console.WriteLine("\nSelect one of the options\n");
                    Console.Write("1. Check Balance \n2. Withraw Money \n3. Dposit Money \n\n");
                    selection = Console.ReadLine();
                    selectionInt = Convert.ToInt32(selection);
                    obj.customerSelection(selectionInt, cardNumber);
                }

            }
        }



        public bool searchCard(string cardNumber, string[,] cardDetails)
        {

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
            string pin="";
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

        public bool validPIN(string pinNumber, string validPIN)
        {
            bool isPinValid = false;

            if (pinNumber == validPIN)
            {
                //Console.WriteLine("PIN is Valid");
                isPinValid = true;
            }
            else
            {
                isPinValid = false;
            }
            return isPinValid;
        }

        public void customerSelection(int selectionInt, string cardNumber)
        {
            switch (selectionInt)
            {
                case 1:
                    //Console.WriteLine("you selected 1");
                    checkBalance(cardNumber);
                    break;
                case 2:
                    //Console.WriteLine("you selected 2");
                    withdrawCash(cardNumber);
                    break;
                case 3:
                    //Console.WriteLine("you selected 3");
                    depositCash(cardNumber);
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
        }

        public void checkFiles(string[,] cardDetails)
        {
            for (int i = 0; i < cardDetails.GetLength(0); i++)
            {
                string path = @"C:\Users\kavit\source\repos\ATM\ATM\Cards\";

                // Create the file if it does not exist.
                if (!File.Exists(path + cardDetails[i, 0] + ".txt"))
                {
                    File.Create(path + cardDetails[i, 0] + ".txt");
                }
            }
        }

        public void checkBalance(string cardNumber)
        {
            string allText = File.ReadAllText(@"C:\Users\kavit\source\repos\ATM\ATM\Cards\" + cardNumber + ".txt");
            Console.WriteLine("The available balance to withraw is: " + allText);
        }

        public void withdrawCash(string cardNumber)
        {
            Console.WriteLine("\nHow much do you want to withdraw?");
            string path = @"C:\Users\kavit\source\repos\ATM\ATM\Cards\" + cardNumber + ".txt";
            string withdraw = Console.ReadLine();
            int withdrawAmt = Convert.ToInt32(withdraw);
            string allText = File.ReadAllText(path);
            int allTextAmt = Convert.ToInt32(allText);

            if (allTextAmt >= withdrawAmt)
            {
                Console.WriteLine("Withdraw Successful!");
                string newBalance = Convert.ToString(allTextAmt - withdrawAmt);
                File.WriteAllText(path, newBalance);

            }
            else
            {
                Console.WriteLine("Insufficient Funds");
            }

        }
        public void depositCash(string cardNumber)
        {
            Console.WriteLine("\nHow much do you want to deposit?");
            string path = @"C:\Users\kavit\source\repos\ATM\ATM\Cards\" + cardNumber + ".txt";
            string deposit = Console.ReadLine();
            int depositAmt = Convert.ToInt32(deposit);
            string allText = File.ReadAllText(path);
            int allTextAmt = Convert.ToInt32(allText);

            Console.WriteLine("Deposit Successful!");
            string newBalance = Convert.ToString(allTextAmt + depositAmt);
            File.WriteAllText(path, newBalance);
        }
    }

}