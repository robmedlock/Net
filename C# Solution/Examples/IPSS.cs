﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://docs.microsoft.com/en-us/dotnet/csharp/linq/group-query-results
namespace Examples
{
    class Patient
    {
        public string Name { get; set; }
        public List<ClinicVisit> ClinicVisits { get; set; }
        public Method Method { get; set; }
    }

    public class ClinicVisit
    {
        public int Qol { get; set; }
    }
    enum Method
    {
        Urolift,
        Rezume
    }
    class GroupExample
    {
        public static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient{Name="Aeron", Method=Method.Urolift, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=1}, new ClinicVisit { Qol=2} }},
                new Patient{Name="Bill", Method=Method.Urolift, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=1}, new ClinicVisit { Qol=2} }},
                new Patient{Name="Charlie", Method=Method.Rezume, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=2}, new ClinicVisit { Qol=3} }},
                new Patient{Name="Dawn", Method=Method.Rezume, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=4}, new ClinicVisit { Qol=6} }}
            };

            //query syntax
            IEnumerable<IGrouping<Method,Patient>> groupedPatients=
                from patient in patients
                group patient by patient.Method into newGroup
                orderby newGroup.Key.ToString()
                select newGroup;

            //method syntax
            IEnumerable<IGrouping<Method, Patient>> groupedPatients2 =
                patients.GroupBy(p => p.Method).OrderBy(ig=>ig.Key.ToString());


            foreach (var methodGroup in groupedPatients2)
            {
                Console.WriteLine($"Key: {methodGroup.Key}");
                Console.WriteLine(methodGroup.Average(p=>p.ClinicVisits.Average(cv=>cv.Qol)));
            }
        }
    }

}
