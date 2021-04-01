using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Software_Engineering_Assignment__Code_
{
    public class GetFromFiles
    {
        private string path;
        public GetFromFiles(string pathParam)
        {
            path = pathParam;
        }
        public string GetUserJson() //gets and opens up the files
        {
            try
            {
                StreamReader inputFile = new StreamReader(path);
                string file = inputFile.ReadToEnd();
                inputFile.Close();
                return file;
            }
            catch (Exception e)
            {
                Console.WriteLine("error Occured when trying to load user information");
                Console.WriteLine(e);
                return "{\"users\":[]}";
            }
        }

        public int GenerateId() // this method isolates the current users Ids so no chance of duplicated IDs
        {
            Users userIdentification = JsonConvert.DeserializeObject<Users>(GetUserJson());
            return userIdentification.users.Max(obj => obj.id) + 1;
        }
    }
}