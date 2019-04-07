namespace HotelWebApiResource.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VdistinctRoomNo")]
    public partial class VdistinctRoomNo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNo { get; set; }
    }
}
