using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {

            bool passed = Enum.TryParse<Corps>(corpsStr, false, out Corps corps);

            if (!passed)
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString() + Environment.NewLine);
            sb.Append($"Corps: {this.Corps.ToString()}");

            return sb.ToString();
        }
    }
}
