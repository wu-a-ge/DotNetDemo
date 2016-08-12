using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace WebCustomControl
{
   public class FaceStyle : TableItemStyle, IStateManager
    {
        #region 类变量

        private bool _blnOK;

        #endregion

        #region 构造函数

        public FaceStyle()
        {
            _blnOK = false;
        }

        #endregion

        #region 属性
       
        [Browsable(true)]
        [Description("自定义类测试变量")]
        public bool OK
        {
            get
            {
                return _blnOK;
            }
            set
            {
                _blnOK = value;
            }
        }

        
        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return base.IsTrackingViewState;
            }
        }

        #endregion

        #region 方法


        //从当前点开始, 此控件具有保存视图状态功能       
        void IStateManager.TrackViewState()
        {
            base.TrackViewState();
        }

       
        object IStateManager.SaveViewState()
        {
            object[] state = new object[2];
            state[0] = base.SaveViewState();            
            
            state[1] = (object)OK;

            //状态管理会存储此返回的值; 另外此方法返回值还有个用途: 创建复合控件时取得各个子控件的视图状态时使用
            return state;
        }

       
        void IStateManager.LoadViewState(object state)
        {
            if (state == null)
            {
                return;
            }
            object[] myState = (object[])state;
            base.LoadViewState(myState[0]);

            OK = (bool)myState[1];                
        }

        #endregion      


    }


}