using System;
using Telephony.Models;

namespace Telephony
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            foreach (var phone in phones)
            {
                smartphone.AddPhone(phone);
            }

            foreach (var website in websites)
            {
                smartphone.AddWebsite(website);
            }

            Console.WriteLine(smartphone.Call());
            Console.WriteLine(smartphone.Browse());
        }
    }
}
