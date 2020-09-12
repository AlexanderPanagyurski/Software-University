using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs = new List<IRepair>();
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString() + Environment.NewLine);
            sb.Append("Repairs:" + Environment.NewLine);

            foreach (var repair in this.repairs)
            {
                sb.Append("  " + repair.ToString() + Environment.NewLine);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
