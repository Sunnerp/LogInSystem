using System;
using System.Linq;
using Newtonsoft.Json;

namespace Software_Engineering_Assignment__Code_
{
    public class Checker
    {
        public string RegisterCheck(string type) //makes the user retype the username and password
        {
            string string1;
            bool stringMatch = false;

            while (stringMatch == false)
            {
                Console.WriteLine("Input a " + type + " :");
                string1 = Console.ReadLine();

                if (string1.Length < 5)
                {
                    Console.WriteLine("Please inout a " + type + " greater than 5 characters");
                    Console.WriteLine("Please try again");
                    RegisterCheck(type);
                }

                Console.WriteLine("Please repeat your " + type + ":");
                var string2 = Console.ReadLine();

                if (string1 == string2)
                {
                    Console.WriteLine(type + " Match");
                    stringMatch = true;
                    return string1;
                }

                else if (string1 != string2)
                {
                    Console.WriteLine(type + " did not match try again");
                }
            }

            return "Error" + type;
        }

        public bool UsernameCheck(string username) //Checks the JSON file to see if the username already exists
        {
            string gotUsername = "";

            GetFromFiles getFromFiles = new GetFromFiles("../../json/json.txt");
            string json = getFromFiles.GetUserJson();

            Users userIdentification = JsonConvert.DeserializeObject<Users>(json);
            var jsonUsername = userIdentification.users.Where(x => x.username == username);

            try
            {
                gotUsername = jsonUsername.First().username;
            }
            catch (Exception e)
            {
                gotUsername = null;
            }

            if (gotUsername == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}