using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator_
{
    public class Class1
    {
        private static string pathReg = @"Name&Password.txt";
        private static string pathToken = @"Tokens.txt";

        public static string Register(String name, String password)
        {
            File.AppendAllText(pathReg, name + "#split#" + password + Environment.NewLine);

            return "Successfully registered";
        }

        public static int Login(string name, string password)
        {
            Random r = new Random();
            int token = 0;
            string n, p;

            string[] lines = File.ReadAllLines(pathReg);

            foreach (string line in lines)
            {
                string[] sepearator = { "#split#" };
                string[] name_password = line.Split(sepearator, StringSplitOptions.None);

                if(name_password.Length == 2)
                {
                    n = name_password[0];
                    p = name_password[1];
                    if (n == name)
                    {
                        if (p == password)
                        {
                            token = r.Next(1000000);
                            Console.WriteLine(n + " " + p + " logged in successfully. token="+token);
                            File.AppendAllText(pathToken, token + Environment.NewLine);
                            //Console.WriteLine("token " + token);
                        }
                    }
                }
            }

            return token;
        }

        public string validate(int token)
        {
            string message = "validated";
            string[] tokenList = File.ReadAllLines(pathToken);

            foreach (string s in tokenList)
            {
                if (int.Parse(s) == token)
                {
                    message = "not validated";
                }
            }

            return message;
        }

        public async void cleanUpTokensAsync(int minutes)
        {
            int mSeconds = minutes * 60 * 1000;
            Task<int> task = new Task<int>(cleanUpTokens);
            await Task.Delay(mSeconds);
            task.Start();
        }

        private int cleanUpTokens()
        {
            File.WriteAllText(pathToken, String.Empty);

            return 0;
        }
    }
}
