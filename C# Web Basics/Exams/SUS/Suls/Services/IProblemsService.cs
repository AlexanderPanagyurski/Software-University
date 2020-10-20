using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IProblemsService
    {
        public void Create(string name, int points);
    }
}
