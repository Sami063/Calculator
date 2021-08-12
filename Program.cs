using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inside MyClass class, i have a void method(GetUserSecurity_nr()) that holds user securityNumber for intering the bank app -
            // than you have posibility to see your balance and deposite money in your acocunt act...
            MyClass f = new MyClass();
            f.GetUserSecurity_nr();
        }

        static void choice() 
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("| Please choose one of the following numbers");
            Console.WriteLine("|1. Check Your Balance");
            Console.WriteLine("|2. Transaction");
            Console.WriteLine("|3. Withdraw money");
            Console.WriteLine("----------------------------------------------");

            // Asking a user to choose one of the following, if the person want to deposite money, withdraw or to check amount balance.
            int userChose;
            userChose = Convert.ToInt32(Console.ReadLine());
            switch (userChose)
            {
                case 1:
                    Account ff = new Account();
                    double ba_la = ff.Balance();

                    break;
                case 2:
                    Account ac = new Account();
                    double amount = ac.TheDeposit();

                    break;
                case 3:
                    Account newAco = new Account();
                    double wd = newAco.TheWithDraw();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input");
                    Console.ResetColor();
                    choice();
                    break;
            }
        }

        // Storing user information => address, name, account number & account balance
        // + User have to inter security code & four degits code before using the app 
        class MyClass
        {
            public void GetUserSecurity_nr()
            {
                // User security information
                double securityNumber = 123456;
                double pinCode = 1234;

                // Get user input security  information
                double  userSecurityNumber;
                double userPinCode;

                // Read user input security  information
                Console.Write("Security number: ");
                userSecurityNumber = Convert.ToDouble(Console.ReadLine());
                Console.Write("Pincode: ");
                userPinCode = Convert.ToDouble(Console.ReadLine());
                if (userSecurityNumber == securityNumber & userPinCode == pinCode)
                {
                    Console.WriteLine("You seccessfully logged in ... ");
                    List<string> userInfor = new List<string>();
                    userInfor.Add("Full Name: Samuel G");
                    userInfor.Add("Address: Bavebakken");
                    userInfor.Add("Account Nr: 2033254545");
                    foreach (string n in userInfor)
                    {
                        Console.WriteLine(n);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Bank Account");
                    Account ff = new Account(); 
                    double ba_la = ff.Balance();
                    Console.WriteLine($"Current Balance: " + "$" + ba_la); // Total balance 
                    Console.WriteLine("----------------------------------");
                    Console.ResetColor();
                    choice();
                } else if(userSecurityNumber != securityNumber)
                { 
                    Console.WriteLine("Incorrect security number");
                    Console.WriteLine("Please try again");
                    GetUserSecurity_nr();
                } else if (userPinCode != pinCode)
                {
                    Console.WriteLine("Incorrect pincode");
                    Console.WriteLine("Please try again");
                    GetUserSecurity_nr();
                }
                else if(userSecurityNumber != securityNumber & userPinCode != pinCode)
                {
                    Console.WriteLine("Incorrect security number & pincode");
                    Console.WriteLine("Please try again");

                    GetUserSecurity_nr();
                }
            }
        }
    }
    
     //Inside my Account class i have three methods - for the Balance, deposit, and for the withdraw amount.
     //In each method, i have calculated fx the withdraw => i recive it as input and substract it with current balance
     //and get the left amount in the account. 
    
    public class Account
    {
        public double currentBalance = 2000;
        public double balance;
        public double deposit_amount;
        public double withDraw_amount;
        // Account balance 
        public double Balance()
        {
            Console.Write("Your total balance is: ");
            Console.WriteLine("$" + currentBalance);
            return currentBalance;
        }
        // User Deposit - this takes deposit as input and add to the currentbalance 
        public double TheDeposit()
        {
            Console.Write("Inter your deposite amount:");
            deposit_amount = Convert.ToDouble(Console.ReadLine());
            if (deposit_amount <= 0 )
            {
                Console.WriteLine("You can't deposit" + " " + "$" + deposit_amount);  
                return TheDeposit();
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                currentBalance += deposit_amount;
                Console.WriteLine("Your current balance is now: " + " " + "$" + currentBalance);
                Console.ResetColor();
                return currentBalance;
            }
        }
        // User WithDraw - this takes withdraw as input and substract it with the currentbalance
        public double TheWithDraw()
        {
            Console.WriteLine("Inter the amount you want to withdraw");
            withDraw_amount = Convert.ToDouble(Console.ReadLine());
            // If user withdraw amount that is greater than currentbalance (user money that is in account) it will ask user that "You have not enogugh money" and ask to input less amount 
            if (withDraw_amount > currentBalance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have not enough money");
                Console.ResetColor();
                Console.WriteLine("Please try again with less amount that you have in your account");
                return TheWithDraw();
                
            } 
            // If user withdraw amount that is less or equal to zerro, it will keep asking user to give the right amount. 
            else if(withDraw_amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't withdraw " + "$" + withDraw_amount);
                Console.ResetColor();
                return TheWithDraw();
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                currentBalance -= withDraw_amount;
                Console.WriteLine("You just withdrawed" + " " + "$" + withDraw_amount);
                Console.WriteLine("Your current balance is now: " + "$" + currentBalance);
                Console.ResetColor();

                return currentBalance;
            }
        }
    }
}
