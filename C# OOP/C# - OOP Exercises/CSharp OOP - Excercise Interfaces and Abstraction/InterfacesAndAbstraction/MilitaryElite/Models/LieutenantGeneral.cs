using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates = new List<ISoldier>();
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
        }

        public IReadOnlyCollection<ISoldier> Privates { get => (IReadOnlyCollection<ISoldier>)this.privates; }

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString() + Environment.NewLine);
            sb.Append("Privates:" + Environment.NewLine);
            foreach (var soldier in this.Privates)
            {
                sb.Append("  " + soldier + Environment.NewLine);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
