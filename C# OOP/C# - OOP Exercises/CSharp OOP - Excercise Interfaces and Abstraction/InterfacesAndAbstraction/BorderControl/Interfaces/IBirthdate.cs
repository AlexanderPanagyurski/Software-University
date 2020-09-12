using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBirthdate
    {
        bool CheckYear(string year);
        string Birthdate { get; }
    }
}
