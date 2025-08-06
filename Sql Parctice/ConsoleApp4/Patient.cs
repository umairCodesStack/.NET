using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Patient
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Disease {  get; set; }
        public Patient() 
        {
            Name = null;
            Email = null;
            Disease = null;
        }
        public Patient(string name, string email, string disease)
        {
            Name = name;
            Email = email;
            Disease = disease;
        }
        public void displayPatientDetails() 
        {
            Console.WriteLine($"Name:{this.Name}");
            Console.WriteLine($"Email:{this.Email}");
            Console.WriteLine($"Disease{this.Disease}");
        }
    }
}
