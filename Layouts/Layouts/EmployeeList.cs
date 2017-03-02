using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace Layouts
{
    public class Employe
    {
        public override string ToString()
        {
            return Name;
        }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public Employe(string name, string position, string email)
        {
            Name = name;
            Position = position;
            Email = email;
        }

    }
    public class EmployeeList
    {
        public Employe[] GetEmployees(int number)
        {
            Employe[] employees = new Employe[number];
            string[] position = { "Supervisor", "Operador", "Gerente", "Director" };
            System.Random rdn = new System.Random();
            for(int i = 0; i < number; i++)
            {
                var name = Guid.NewGuid().ToString().Substring(0, 10);
                var newEmployee = new Employe(name, position[rdn.Next(0, 3)], name + "@myCompany.com");
                employees[i] = newEmployee;
            }
            return employees;

        }




    }
}