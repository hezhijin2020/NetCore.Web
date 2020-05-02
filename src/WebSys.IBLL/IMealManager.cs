using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSys.IBLL
{
    public interface IMealManager
    {
        /// <summary>
        /// 获取用户指定日期的报取餐信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="mealday">报餐日期</param>
        /// <returns>报取餐信息</returns>
        Task<Dto.MealDto> GetMealByDay(Guid userId, DateTime mealday);

        /// <summary>
        /// 获取用户指定时间的报取餐信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="startday">开始日期</param>
        /// <param name="endday">结束日期</param>
        /// <returns></returns>
        Task<List<Dto.MealDto>> GetMealByDay(Guid userId, DateTime startday, DateTime endday);

        /// <summary>
        /// 提交报餐信息
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        Task SetMealByDto(Dto.MealDto dto);
    }
}