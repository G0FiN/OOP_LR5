using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class Degree
    {        
        private bool bachelor;
        public bool Bachelor { get => bachelor; set => bachelor = value; }
        private bool specialist;
        public bool Specialist { get => specialist; set => specialist = value; }
        private bool master;
        public bool Master { get => master; set => master = value; }

        public override string ToString() {
            string result;
            result = Bachelor ? "\tBachelor - OK\n\t" : "\tBachelor - X\n\t";
            result += Specialist ? "Specialist - OK\n\t" : "Specialist - X\n\t";
            result += Master ? "Master - OK\n\t" : "Master - X\n";
            return result;
        }        
    }
}
