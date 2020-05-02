using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSys.Models
{
    public class ys_OrderMeal : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ACL_User User { get; set; }
        public DateTime Mealday { get; set; }
        public int Zaocan { get; set; } = 0;
        public int IsZaocan { get; set; } = 0;
        public DateTime Zaocantime { get; set; }

        public int Zhongcan { get; set; } = 0;
        public int IsZhongcan { get; set; } = 0;
        public DateTime Zhongcantime { get; set; }

        public int Wancan { get; set; } = 0;
        public int IsWancan { get; set; } = 0;
        public DateTime Wancantime { get; set; }

        public Guid OrderUserId { get; set; } = Guid.Empty;

        public Guid EditUserId { get; set; } = Guid.Empty;
        public DateTime Edittime { get; set; }
    }
}