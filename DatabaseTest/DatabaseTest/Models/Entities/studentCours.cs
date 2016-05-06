namespace DatabaseTest.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("studentCourses")]
    public partial class studentCours
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int userID { get; set; }

        public int courseID { get; set; }

        public virtual cours cours { get; set; }

        public virtual user user { get; set; }
    }
}
