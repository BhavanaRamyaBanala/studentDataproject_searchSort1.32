using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1._32
{
    public class Student
    {
        public string Name { get; }
        public string ClassName { get; }

        public Student(string name, string className)
        {
            Name = name;
            ClassName = className;
        }
    }
}
