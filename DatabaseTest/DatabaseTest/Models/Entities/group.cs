namespace DatabaseTest.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        public int userID { get; set; }

        public int assignmentID { get; set; }

        public virtual assignment assignment { get; set; }

        public virtual user user { get; set; }
    }
}
