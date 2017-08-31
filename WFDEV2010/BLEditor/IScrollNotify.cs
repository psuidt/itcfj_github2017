using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLEditor
{

        /// <summary>
        /// 提供编辑控件的滚动条参数改变时的通知和同步功能
        /// </summary>
        public interface IScrollNotify
        {
            /// <summary>
            /// 垂直滚动条发生改变事件
            /// </summary>
            event EventHandler<ScrollArgs> VScrollChanged;

            /// <summary>
            /// 设置垂直滚动条的滚动框位置
            /// </summary>
            /// <param name="pos"></param>
            void SetVScrollPos(int pos);

        }
    }

