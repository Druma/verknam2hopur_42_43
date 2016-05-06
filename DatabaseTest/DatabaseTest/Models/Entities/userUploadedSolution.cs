namespace DatabaseTest.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userUploadedSolution")]
    public partial class userUploadedSolution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string solution { get; set; }

        public int userID { get; set; }

        public int assignmentPartID { get; set; }

        public virtual assignmentPart assignmentPart { get; set; }

        public virtual user user { get; set; }
    }
}
