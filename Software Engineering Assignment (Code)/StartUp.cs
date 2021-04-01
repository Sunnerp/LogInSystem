using System;

namespace Software_Engineering_Assignment__Code_
{
    class StartUp
    {
        static void Main() // start of the application
        {
            Console.WriteLine("Welcome to P-Protect your private Log-In management System");
            StartMenu();
        }

        static void StartMenu() //first menu to allow user to select where they would like to go
        {
            RegisterAccount Ra = new RegisterAccount();
            LogInSystem log = new LogInSystem();
            bool answer = false;
            int choice = 0;



            while (answer == false)
            {
                try
                {
                    Console.WriteLine("Please select a number from the menu:");
                    Console.WriteLine(" 1 - Log into your account \n 2 - Register Account \n 3 - About");

                    int userChoice = int.Parse(Console.ReadLine());
                    choice = userChoice;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Try inputting a number based on which menu option you want.");
                }

                if (choice == 1)
                {
                    log.LogIn();
                    answer = true;
                }
                else if (choice == 2)
                {

                   Ra.RegisterMain();
                }
                else if (choice == 3)
                {
                    About();
                    Main();
                }
                else
                {
                    Console.WriteLine("Please Input Valid Choice");
                }
            }
        }

        private static void About() // the about output
        {
            Console.WriteLine("This is private system which allows users to Log into a secure account.");
        }
    }
}
