using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayersAndMonsters.IO.Contracts
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            using (StreamWriter file = new StreamWriter(@"./result.txt", true))
            {
                file.WriteLine(message);
            }

            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            using (StreamWriter file = new StreamWriter(@"./result.txt", true))
            {
                file.WriteLine(message);
            }

            Console.WriteLine(message);
        }
    }
}
