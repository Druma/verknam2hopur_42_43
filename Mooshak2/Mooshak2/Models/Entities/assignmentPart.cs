namespace Mooshak2
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web;
	public partial class assignmentPart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public assignmentPart()
        {
            userAssignmentStats = new HashSet<userAssignmentStat>();
            userUploadedSolutions = new HashSet<userUploadedSolution2>();
        }

        public int ID { get; set; }

        public string descriptoin { get; set; }

        
        public string solutionFile { get; set; }

        public int assignmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userAssignmentStat> userAssignmentStats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userUploadedSolution2> userUploadedSolutions { get; set; }
    }
}
