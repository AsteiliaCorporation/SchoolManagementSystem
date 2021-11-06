using System;

namespace SchoolManagementSystem.Classes
{
    internal class Subject
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Grades { get; set; }

        public Subject(int _number, string _name, double _grade1, double _grade2, double _grade3, double _grade4)
        {
            Number = _number;
            Name = _name;
            Grades = "" + _grade1 + ", " + _grade2 + ", " + _grade3 + ", " + _grade4;
        }
    }
}
