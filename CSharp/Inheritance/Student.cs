using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Student : Person
    {
        public int studentNum { get; set; }
        public char averageMark { get; set; }
        public bool isEligibleToEntroll
        {
            get
            {
                return averageMark == 'A';
            }
        }
        private string[] seminarsTaken;
        public bool takenSeminars
        {
            get
            {
                return seminarsTaken != null &&
                    seminarsTaken.Length > 0;
            }
        }
        public Student(string name, int phoneNumber, string emailAddress) 
            : base(name, phoneNumber, emailAddress)
        {
        }

        public void TakeSeminars(string[] seminars)
        {
            seminarsTaken = seminars;
        }
    }
}
