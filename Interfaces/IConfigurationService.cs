using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IConfigurationService
    {
        T Get<T>(string name) where T : new();
        string GetString(string name);
    }
}
