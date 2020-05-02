using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSys.Dto;
using WebSys.IBLL;

namespace WebSys.BLL
{
    public class MealManager : IMealManager
    {
        private IDAL.IMealService service = new DAL.MealService();

        /// <summary>
        /// 获取用户指定日期的报取餐信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="mealday">报餐日期</param>
        /// <returns>报取餐信息</returns>
        public async Task<Dto.MealDto> GetMealByDay(Guid userId, DateTime mealday)
        {
            Dto.MealDto dto = await service.GetALLAsync().Include(a => a.User)
                   .Select(b => new MealDto
                   {
                       UserId = b.UserId,
                       Edittime = b.Edittime,
                       EditUserId = b.EditUserId,
                       IsWancan = b.IsWancan,
                       IsZaocan = b.IsZaocan,
                       IsZhongcan = b.IsZhongcan,
                       Mealday = b.Mealday,
                       OrderUserId = b.OrderUserId,
                       UserName = b.User.FullName,
                       DepartmentName = b.User.Department.DepartmentName,
                       Wancan = b.Wancan,
                       Zaocan = b.Zaocan,
                       Zaocantime = b.Zaocantime,
                       Zhongcan = b.Zhongcan,
                       Wancantime = b.Wancantime,
                       Zhongcantime = b.Zhongcantime
                   }).FirstOrDefaultAsync(s => s.UserId == userId && s.Mealday == mealday.Date);
            if (dto == null)
            {
                dto = new MealDto { UserId = userId, Mealday = mealday, Zaocan = 0, Zhongcan = 0, Wancan = 0 };
            }
            return dto;
        }

        /// <summary>
        /// 获取用户指定时间的报取餐信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startday">开始日期</param>
        /// <param name="endday">结束日期</param>
        /// <returns></returns>
        public async Task<List<Dto.MealDto>> GetMealByDay(Guid userId, DateTime startday, DateTime endday)
        {
            return await service.GetALLAsync().Include(a => a.User)
                 .Select(b => new MealDto
                 {
                     UserId = b.UserId,
                     Edittime = b.Edittime,
                     EditUserId = b.EditUserId,
                     IsWancan = b.IsWancan,
                     IsZaocan = b.IsZaocan,
                     IsZhongcan = b.IsZhongcan,
                     Mealday = b.Mealday,
                     OrderUserId = b.OrderUserId,
                     UserName = b.User.FullName,
                     DepartmentName = b.User.Department.DepartmentName,
                     Wancan = b.Wancan,
                     Zaocan = b.Zaocan,
                     Zaocantime = b.Zaocantime,
                     Zhongcan = b.Zhongcan,
                     Wancantime = b.Wancantime,
                     Zhongcantime = b.Zhongcantime
                 }).Where(c => c.UserId == userId && (c.Mealday >= startday.Date && c.Mealday <= endday.Date)).ToListAsync<MealDto>();
        }

        /// <summary>
        /// 提交报餐信息
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public async Task SetMealByDto(Dto.MealDto dto)
        {
            if (service.GetALLAsync().Any(a => a.UserId == dto.UserId && a.Mealday == dto.Mealday.Date))
            {
                Models.ys_OrderMeal model = service.GetALLAsync().FirstOrDefault(a => a.UserId == dto.UserId && a.Mealday == dto.Mealday);

                model.UserId = dto.UserId;
                model.EditUserId = dto.EditUserId;
                model.Edittime = dto.Edittime;
                model.IsWancan = dto.IsWancan;
                model.Wancan = dto.Wancan;
                model.Wancantime = dto.Wancantime.Date;
                model.Zaocan = dto.Zaocan;
                model.Zaocantime = dto.Zaocantime;
                model.IsZaocan = dto.IsZaocan;
                model.Zhongcan = dto.Zhongcan;
                model.Zhongcantime = dto.Zhongcantime;
                model.IsZhongcan = dto.IsZhongcan;
                model.Mealday = dto.Mealday;
                model.OrderUserId = dto.OrderUserId;
                await service.EditAsync(model);
            }
            else
            {
                await service.CreateAsync(new Models.ys_OrderMeal()
                {
                    UserId = dto.UserId,
                    EditUserId = dto.EditUserId,
                    Edittime = dto.Edittime,
                    Id = Guid.NewGuid(),
                    IsWancan = dto.IsWancan,
                    Wancan = dto.Wancan,
                    Wancantime = dto.Mealday,
                    Zaocan = dto.Zaocan,
                    Zaocantime = dto.Mealday,
                    IsZaocan = dto.IsZaocan,
                    Zhongcan = dto.Zhongcan,
                    Zhongcantime = dto.Mealday,
                    IsZhongcan = dto.IsZhongcan,
                    Mealday = dto.Mealday,
                    OrderUserId = dto.OrderUserId
                });
            }
        }
    }
}