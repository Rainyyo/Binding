using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest.Model
{
    public  class Person//默认为internal，将internal改为public
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Info { get; set; }
    }
}
