using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Person : IAttackable
    {
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }
        public int phoneNumber { get; private set; }
        public string emailAddress { get; private set; }    
        public Person(string name, int phoneNumber, string emailAddress)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }

        public void PurchaseParkingPass()
        {
            Console.WriteLine($"{name} : 주차권 구매 완료");
        }

        public void Attack()
        {
            Console.WriteLine($"{name} (이)가 공격했다");
        }
    }
}
