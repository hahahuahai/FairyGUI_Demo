using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace FairyGuiDemo
{

    public class WindowManager
    {
        protected Dictionary<string, Window> windowsPool;
        #region 单例
        static WindowManager _inst;
        public static WindowManager inst
        {
            get
            {
                if (_inst == null)
                    Instantiate();
                return _inst;
            }
        }

        static void Instantiate()
        {
            if (_inst == null)
            {
                _inst = new WindowManager();
            }
        }
        private WindowManager()
        {
            windowsPool = new Dictionary<string, Window>();
        }
        #endregion

        /// <summary>
        /// 添加所有窗口
        /// </summary>
        public void AddAllWindow()
        {
            inst.AddWindow("StartWindow", new StartWindow());
            inst.AddWindow("LinkWindow", new LinkWindow());
        }

        void AddWindow(string windowname, Window windowClass)
        {
            Window win;
            if (!windowsPool.TryGetValue(windowname, out win))
            {
                windowsPool.Add(windowname, windowClass);
            }
        }

        /// <summary>
        /// 根据窗口名称得到窗口对象
        /// </summary>
        /// <param name="windowname"></param>
        /// <returns></returns>
        public Window GetWindowByName(string windowname)
        {
            Window win;
            if (windowsPool.TryGetValue(windowname, out win))
            {
                return win;
            }
            return null;
        }
    }

}
