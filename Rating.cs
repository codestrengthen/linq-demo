namespace LINQDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int RatingID { get; set; }

        public int ResID { get; set; }

        public int CustomerID { get; set; }

        public int RatingValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
