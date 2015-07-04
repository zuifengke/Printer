using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windy.Printer
{
    public struct SystemConst
    { /// <summary>
        /// 返回值常量
        /// </summary>
        public struct ReturnValue
        {
            /// <summary>
            /// 返回值=0
            /// </summary>
            public const short OK = 0;

            /// <summary>
            /// 返回值=1
            /// </summary>
            public const short FAILED = 1;

            /// <summary>
            /// 返回值=2
            /// </summary>
            public const short CANCEL = 2;

            /// <summary>
            /// 返回值=3
            /// </summary>
            public const short EXCEPTION = 3;
        }

    }
}
