using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_29_ExpTree
{
    public class Student
    {
        public int Age { get; set; }
        public string Name {  get; set; }
        public char Group {  get; set; }
        public Student(string name, int age, char group)
        {
            Age = age;
            Name = name;
            Group = group;
        }

    }
}
