using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Layouts
{
    [Activity(Label = "Layouts", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListView);

            // Get our button from the layout resource,
            // and attach an event to it
            EmployeeList employeeList = new EmployeeList();
            var employees = employeeList.GetEmployees(20);

            ListView lvlEmployee = FindViewById<ListView>(Resource.Id.employee);

            EmployeeAdapter adapter = new EmployeeAdapter(employees);
          
            lvlEmployee.Adapter = adapter;

        }
    }
}

