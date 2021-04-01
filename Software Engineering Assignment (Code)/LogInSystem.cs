using System;
using System.Linq;

using Newtonsoft.Json;

namespace Software_Engineering_Assignment__Code_
{
    public class LogInSystem
    {
        public void LogIn() //Log in class
        {
            Checker checker = new Checker();
            GetFromFiles getFile = new GetFromFiles("../../json/json.txt");
            bool credientalMatch = false;

            var userUsername = checker.RegisterCheck("Username");
            var userPassword = checker.RegisterCheck("Password");

            while (credientalMatch == false)
            {
                credientalMatch = CredientailCheck(userUsername, userPassword, getFile.GetUserJson());
                if (credientalMatch == false)
                {
                    Console.WriteLine("Username or password wrong");
                    LogIn();
                }
            }

            Console.WriteLine("Successful Log in");
        }

        private bool CredientailCheck(string username, string password, string json) //takes in the username and password the user has input and check to see if these credentals exit in the json.
        {
            try
            {
                Users userIdentification = JsonConvert.DeserializeObject<Users>(json);

                var jsonUsername = userIdentification.users.Where(x => x.username == username);
                string usernamePassword =jsonUsername.First().password;

                if (usernamePassword == password)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("No match, try again");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No match");
                return false;
            }
        }

        
    }
}