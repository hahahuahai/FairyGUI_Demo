using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace FairyGuiDemo
{
    public class StartWindow : Window
    {

        GButton start_btn;
        GButton quit_btn;

        public StartWindow()
        {

        }

        protected override void OnInit()
        {
            base.OnInit();
            this.contentPane = UIPackage.CreateObject("LinkGame", "StartWin").asCom;
            this.Center();

            start_btn = this.contentPane.GetChild("start_btn").asButton;
            quit_btn = this.contentPane.GetChild("quit_btn").asButton;

            start_btn.onClick.Add(OnStartBtnClicked);
            quit_btn.onClick.Add(OnQuitBtnClicked);
        }

        void OnStartBtnClicked(EventContext eventContext)
        {
            GRoot.inst.DispatchEvent(EventCmd.OpenLinkWindow);
        }

        void OnQuitBtnClicked(EventContext eventContext)
        {

        }
    }

}
