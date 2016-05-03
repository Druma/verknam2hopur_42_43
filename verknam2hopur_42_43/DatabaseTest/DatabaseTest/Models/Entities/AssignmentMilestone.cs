using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseTest.Models.Entities
{
    // A milestone in an assignment is worth some part of the assignment
    // Each milestone thus has a weight representing its importance
    //Assigment ID is a key to the assignment

    public class AssignmentMilestone
    {
        public int ID { get; set; }
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
    }
}