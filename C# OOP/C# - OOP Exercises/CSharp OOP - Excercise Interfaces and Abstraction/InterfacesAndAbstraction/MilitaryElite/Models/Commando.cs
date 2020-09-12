using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMisson> missons = new List<IMisson>();
        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
        }

        public IReadOnlyCollection<IMisson> Missons => (IReadOnlyCollection<IMisson>)this.missons;

        public void AddMission(IMisson misson)
        {
            this.missons.Add(misson);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString() + Environment.NewLine);
            sb.Append("Missions:" + Environment.NewLine);

            foreach (var misson in this.missons)
            {
                sb.Append("  " + misson.ToString() + Environment.NewLine);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
