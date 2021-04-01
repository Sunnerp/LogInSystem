using System;
using System.IO;
using Newtonsoft.Json;

namespace Software_Engineering_Assignment__Code_
{
    public class RegisterAccount
    {
        public void RegisterMain() // register a new user class
        {
            Checker checker = new Checker();
            GetFromFiles getFromFiles = new GetFromFiles("../../json/json.txt");
            int id = getFromFiles.GenerateId();

            var username = UsernameAvailableCheck();
            var password = checker.RegisterCheck("Password");


            UserIdentification ui = new UserIdentification();
            ui.username = username;
            ui.password = password;
            ui.id = id;

            string json =getFromFiles.GetUserJson();

            Users user = JsonConvert.DeserializeObject<Users>(json);

            user.users.Add(ui);

            string editedJson = JsonConvert.SerializeObject(user);

            string path = "../../json/json.txt";
            StreamWriter outputFile = new StreamWriter(path);

            outputFile.WriteLine(editedJson);

            outputFile.Flush();

            outputFile.Close();
        }

        private string UsernameAvailableCheck() //if the username is taken prompts the user to try another username.
        {
            Checker checker = new Checker();
            var username = checker.RegisterCheck("Username");
            bool available = checker.UsernameCheck(username);

            if (available == false)
            {
                Console.WriteLine("Username is not available please try another");
                UsernameAvailableCheck();
            }

            return username;
        }
    }
}
