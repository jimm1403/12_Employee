using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Employee
{
    public interface IEmployee
    {
        string Name { get; set; }
        string Type { get; set; }
        int Id { get; set; }
    }
}
