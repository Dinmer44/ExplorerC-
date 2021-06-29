using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MyTag
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public MyTag(string n)
        {
            name = n;
        }
        
    }
}
