//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mooshak2
{
    using System;
    using System.Collections.Generic;
    
    public partial class assignmentParts
    {
        public assignmentParts()
        {
            this.userAssignmentStats = new HashSet<userAssignmentStats>();
            this.userUploadedSolution = new HashSet<userUploadedSolution>();
        }
    
        public int ID { get; set; }
        public string descriptoin { get; set; }
        public string solutionFile { get; set; }
        public int assignmentID { get; set; }
    
        public virtual ICollection<userAssignmentStats> userAssignmentStats { get; set; }
        public virtual ICollection<userUploadedSolution> userUploadedSolution { get; set; }
    }
}