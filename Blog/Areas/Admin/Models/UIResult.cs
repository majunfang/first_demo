using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UIResult
    {
            /// <summary>
            /// 操作是否成功
            /// </summary>
            public bool success { get; set; }
            /// <summary>
            /// 消息
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string remark { get; set; }
            public UIResult(bool suc, string msg)
            {
                this.success = suc;
                this.message = msg;
            }
            public UIResult(bool suc, string msg, string rmk)
            {
                this.success = suc;
                this.message = msg;
                this.remark = rmk;
            }
        }

    }