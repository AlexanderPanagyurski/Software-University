using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IFeline:IMammal
    {
        string Breed { get; }
    }
}
