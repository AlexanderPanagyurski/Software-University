using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
