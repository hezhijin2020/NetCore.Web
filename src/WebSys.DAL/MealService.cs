using WebSys.IDAL;

namespace WebSys.DAL
{
    public class MealService : BaseService<Models.ys_OrderMeal>, IMealService
    {
        public MealService() : base(new Models.WebSysDBContext())
        {
        }
    }
}