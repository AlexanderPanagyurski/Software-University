using MilitaryElite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString() + Environment.NewLine);
            sb.Append($"Code Number: {this.CodeNumber}");

            return sb.ToString();
        }
    }
}
