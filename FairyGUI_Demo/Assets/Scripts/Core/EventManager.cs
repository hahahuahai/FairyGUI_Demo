﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace FairyGuiDemo
{

    public class EventManager
    {
        #region 单例
        static EventManager _inst;
        public static EventManager inst
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
                _inst = new EventManager();
            }
        }
        private EventManager() { }
        #endregion

        public void Init()
        {
            //添加全局监听事件
            GRoot.inst.AddEventListener(EventCmd.OpenLinkWindow, OnOpenLinkWindow);
            
        }

        void OnOpenLinkWindow()
        {
            Debug.Log("111111");
            var startwindow = WindowManager.inst.GetWindowByName("StartWindow");
            startwindow.Hide();
            var linkwindow = WindowManager.inst.GetWindowByName("LinkWindow");
            linkwindow.Show();
        }
    }

}