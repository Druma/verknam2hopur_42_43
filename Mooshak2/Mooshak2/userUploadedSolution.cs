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
    
    public partial class userUploadedSolution
    {
      //  public int ID { get; set; }
      //  public string solution { get; set; }
      //  public int userID { get; set; }
     //   public int assignmentPartID { get; set; }
    
        public virtual assignmentParts assignmentParts { get; set; }
        public virtual users users { get; set; }
    }
}
