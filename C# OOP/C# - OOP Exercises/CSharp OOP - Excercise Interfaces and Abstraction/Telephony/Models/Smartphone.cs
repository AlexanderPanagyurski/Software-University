using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        private readonly IList<string> phones;
        private readonly IList<string> websites;

        public Smartphone()
        {
            this.phones = new List<string>();
            this.websites = new List<string>();
        }

        public string Call()
        {
            return string.Join(Environment.NewLine, this.phones);
        }

        public string Browse()
        {
            return string.Join(Environment.NewLine, this.websites);
        }

        public void AddPhone(string phone)
        {
            this.phones.Add(int.TryParse(phone, out int number) ? $"Calling... {phone}" : "Invalid number!");
            if (phone.Length==7)
            {
                this.phones.Remove(this.phones[phones.Count - 1]);
                this.phones.Add( $"Dialing... {phone}");
            }
        }

        public void AddWebsite(string website)
        {
            if (HasDigit(website))
            {
                this.websites.Add("Invalid URL!");
            }
            else
            {
                this.websites.Add($"Browsing: {website}!");
            }
        }

        private bool HasDigit(string website)
        {
            bool hasDigit = false;

            foreach (var symbol in website)
            {
                if (char.IsDigit(symbol))
                {
                    return hasDigit = true ;
                }
            }
            return hasDigit;
        }
    }
}
