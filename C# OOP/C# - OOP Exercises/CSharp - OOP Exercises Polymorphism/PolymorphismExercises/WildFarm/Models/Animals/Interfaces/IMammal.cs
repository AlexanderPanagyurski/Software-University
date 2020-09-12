using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IMammal:IAnimal
    {
        string LivingRegion { get; }
    }
}
