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
    
    public partial class groups2
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int userID { get; set; }
        public int assignmentID { get; set; }
    
        public virtual assignments2 assignments { get; set; }
        public virtual users2 users { get; set; }
    }
}
