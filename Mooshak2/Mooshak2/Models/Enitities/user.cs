namespace Mooshak2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            groups = new HashSet<group>();
            studentCourses = new HashSet<studentCours>();
            teacherCourses = new HashSet<teacherCours>();
            userAssignmentStats = new HashSet<userAssignmentStat>();
            userUploadedSolutions = new HashSet<userUploadedSolution>();
        }

        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public int userTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<group> groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<studentCours> studentCourses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacherCours> teacherCourses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userAssignmentStat> userAssignmentStats { get; set; }

        public virtual userType userType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userUploadedSolution> userUploadedSolutions { get; set; }
    }
}
