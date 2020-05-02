namespace WebSys.APIWork.vModels.ResponsevModel
{
    public class ResponseData
    {
        /// <summary>
        /// 响应代码 200成功
        /// </summary>
        public int Code { get; set; } = 200;

        /// <summary>
        /// Object类型的数据，用于装对象
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg { get; set; }
    }
}