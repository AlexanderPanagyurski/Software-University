using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMisson> Missons { get; }

        void AddMission(IMisson misson);
    }
}
