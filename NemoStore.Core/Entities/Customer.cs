using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NemoStore.Core.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Column("WEIXINID")]
        [Key]
        [MaxLength(100)]
        public string WeiXinId { get; set; }

        [Column("HEADIMGURL")]
        [MaxLength(500)]
        public string HeadImgUrl { get; set; }

    }
}
