using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebSys.APIWork.vModels.ResponsevModel;

namespace WebSys.APIWork.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderMealController : ControllerBase
    {
        private IBLL.IMealManager mealMg = new BLL.MealManager();
        private Guid UserId = Guid.Parse("63319D86-DAFB-40B1-996C-D837D8887379");

        /// <summary>
        /// 获取指定日期报取餐信息
        /// </summary>
        /// <param name="day">指定的日期</param>
        /// <returns></returns>
        [Route("GetMealByDay")]
        [HttpGet]
        public async Task<ResponseData> GetMealByDayAsync(DateTime day)
        {
            try
            {
                Dto.MealDto dto = await mealMg.GetMealByDay(UserId, day);
                return new ResponseData() { Data = dto, Msg = "成功" };
            }
            catch (Exception ex)
            {
                return new ResponseData() { Code = 500, Msg = "服务器错误" };
            }
        }

        /// <summary>
        /// 获取指定日期范围的报取餐信息
        /// </summary>
        /// <param name="startday">开始日期</param>
        /// <param name="endday">结束日期</param>
        /// <returns></returns>
        [Route("GetMealByDays")]
        [HttpGet]
        public async Task<ResponseData> GetMealByDaysAsync(DateTime startday, DateTime endday)
        {
            try
            {
                var dto = await mealMg.GetMealByDay(UserId, startday, endday);
                return new ResponseData() { Data = dto, Msg = "成功" };
            }
            catch (Exception ex)
            {
                return new ResponseData() { Code = 500, Msg = "服务器错误" };
            }
        }

        /// <summary>
        /// 提交报餐信息
        /// </summary>
        /// <param name="dto">dto实体信息</param>
        /// <returns></returns>
        [Route("SetMealByDto")]
        [HttpPost]
        public async Task<ResponseData> SetMealByDtoAsync(Dto.MealDto dto)
        {
            try
            {
                await mealMg.SetMealByDto(dto);
                return new ResponseData() { Msg = "成功" };
            }
            catch (Exception ex)
            {
                return new ResponseData() { Code = 500, Msg = "服务器错误" };
            }
        }
    }
}