namespace Mooshak2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public assignment()
        {
            groups = new HashSet<group>();
        }

        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        public int? maxSubmisions { get; set; }

        public int? groupSize { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int courseID { get; set; }

        public virtual cours cours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<group> groups { get; set; }
    }
}
