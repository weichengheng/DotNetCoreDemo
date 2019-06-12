using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ken.Tutorial.Web.Models.Entity
{
    [Table("bill_detail_sync2sap_log")]
    public class BillDetailSync2SapLogEntity
    {
        [Key]//主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自增列
        [Column("ID")]
        public int ID { get; set; }

        [Column("SyncDate")]
        public DateTime SyncDate { get; set; }

        [Column("SyncState")]
        public int SyncState { get; set; }

        [Column("Msg")]
        public String Msg { get; set; }

        [Column("CreateTime")]
        public DateTime CreateTime { get; set; }

        [Column("SyncFinalState")]
        public int SyncFinalState { get; set; }
    }
}
