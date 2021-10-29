using Domain.Models;
using EventsManagemtns.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Runtime.Intrinsics.X86;
namespace EventsManagemtns.Models
{
    public class Tasks
    {
        public int id { get; set; }
        public string description { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
        public string title { get; set; }
        public int importance { get; set; }
        public int taskOwner { get; set; }
        public int urgent { get; set; }
        public Status status { get; set; }
        public Section assigned_for { get; set; }
        public IList<Employee> assignedEmps { get; set; }
        public int weights { get; set; }
        public string actions { get; set; }
        public string date { get; set; }
        public string dueDate { get; set; }
        public IList<Comment> comments { get; set; } 
        public Incident parentIncident { get; set; }
        public CloseReport closingReport { get; set; }
        public Tasks parentTask { get; set; }

        public int progress { get; set; }
        public int rate { get; set; }
    }
}