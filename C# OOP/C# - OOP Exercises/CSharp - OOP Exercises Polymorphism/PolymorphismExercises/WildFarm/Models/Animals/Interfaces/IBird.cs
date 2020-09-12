using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
