using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class Person
    {
        public string Name{ get; set; }
        public string LastName { get; set; }
        public List<string> ListOfObjects { get; set; }
        public override string ToString()
        {
            return $"{Name } {LastName}";
        }


    }
}
