using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace FairyGuiDemo
{
    public class FinishWindow : Window
    {
        GButton quit_btn;
        public FinishWindow() { }

        protected override void OnInit()
        {
            base.OnInit();

            this.contentPane = UIPackage.CreateObject("LinkGame", "FinishWin").asCom;
            this.Center();
            
            quit_btn = this.contentPane.GetChild("quit_btn").asButton;
            quit_btn.onClick.Add(OnQuitBtnClicked);
        }

        void OnQuitBtnClicked(EventContext eventContext)
        {
            Application.Quit();
        }
    }

}
