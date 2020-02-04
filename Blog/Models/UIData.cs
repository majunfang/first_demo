using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UIData
    {
        /// <summary>
        /// 信息编号
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// 信息名称
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 特色图片路径
        /// </summary>
        public String PicUrl { get; set; }
        /// <summary>
        /// 其他数据
        /// </summary>
        public Object Data { get; set; }
    }
}