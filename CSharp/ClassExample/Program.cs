using System;

namespace ClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human();
            Human human2 = new Human();

            human1.SetInfo(100, 200f, "Man");
            human2.SetInfo(50, 150f, "Woman");

            human1.PrintAge();
            human2.PrintAge();
        }
    }
    internal class Human
    {
        internal int age;
        internal float height;
        internal string gender;

        public void SetInfo(int _age, float _height, string _gender)
        {
            age = _age;
            height = _height;
            gender = _gender;
        }
        public void PrintAge()
        {
            Console.WriteLine(age);
        }
    }
}
