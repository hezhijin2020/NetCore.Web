using System;

namespace WebSys.Dto
{
    public class MealDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
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