using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Adress adress{  get; set; }
    }
    public class Adress 
    {
        public string City {  get; set; }
        public string Country{ get; set; }
        public int Zip { get; set; }
    }
}