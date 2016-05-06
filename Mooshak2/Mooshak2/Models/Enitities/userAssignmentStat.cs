namespace Mooshak2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class userAssignmentStat
    {
        public int ID { get; set; }

        public int submissionCount { get; set; }

        public bool solved { get; set; }

        public int userID { get; set; }

        public int assignmentPartID { get; set; }

        public virtual assignmentPart assignmentPart { get; set; }

        public virtual user user { get; set; }
    }
}
