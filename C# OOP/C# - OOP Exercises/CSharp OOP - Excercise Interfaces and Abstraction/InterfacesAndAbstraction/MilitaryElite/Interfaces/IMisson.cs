using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IMisson
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
