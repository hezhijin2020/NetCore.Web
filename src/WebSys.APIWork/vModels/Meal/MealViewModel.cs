using System;

namespace WebSys.APIWork.vModels.Meal
{
    public class MealViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Mealday { get; set; }
        public int Zaocan { get; set; } = 0;

        //public int IsZaocan { get; set; } = 0;
        //public DateTime Zaocantime { get; set; }
        public int Zhongcan { get; set; } = 0;

        //public int IsZhongcan { get; set; } = 0;
        //public DateTime Zhongcantime { get; set; }
        public int Wancan { get; set; } = 0;

        //public int IsWancan { get; set; } = 0;
        //public DateTime Wancantime { get; set; }
    }
}