﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace FairyGuiDemo
{

    public class LinkWindow : Window
    {
        GList LinkList;
        GTextField scoreText;
        
        GButton firstClick = new GButton();
        GButton secondClick = new GButton();
        bool isFirstClicked = true; // 判断玩家是否第一次点击
        double currentScore;

        public LinkWindow()
        {

        }

        protected override void OnInit()
        {
            base.OnInit();
            this.contentPane = UIPackage.CreateObject("LinkGame", "LinkWin").asCom;
            this.Center();

            LinkList = this.contentPane.GetChild("list").asList;
            LinkList.itemRenderer = RenderListItem;
            LinkList.numItems = 40; //必须是能被20整除的数字，才会使得游戏逻辑没漏洞
            LinkList.onClickItem.Add(OnLinkListClicked);
                       
            scoreText = this.contentPane.GetChild("score_txt").asTextField;
            currentScore = 0;
            scoreText.SetVar("score", currentScore.ToString()).FlushVars();
           
            this.AddEventListener(EventCmd.ScoreOne, PlusScore);
        }

        void RenderListItem(int index, GObject obj)
        {
            GButton button = (GButton)obj;
            while (index >= 10)
            {
                index %= 10;
            }
            button.icon = "Pics/" + "i" + index;
            button.title = "i" + index;
        }

        void OnLinkListClicked(EventContext eventContext)
        {
            GButton item = (GButton)eventContext.data;
            if (isFirstClicked)//第一次点击
            {
                firstClick = item;
                isFirstClicked = false;
                return;
            }
            if (!isFirstClicked)//第二次点击
            {
                secondClick = item;
                isFirstClicked = true;
            }
            if (firstClick.title == secondClick.title && firstClick.id != secondClick.id)//两次点击的图片一致，且不是自己
            {
                firstClick.visible = false;
                secondClick.visible = false;
                this.DispatchEvent(EventCmd.ScoreOne);
            }
            bool isfinish = IsFinishGame();
            if (isfinish)
            {
                GRoot.inst.DispatchEvent(EventCmd.FinishGame);
            }
        }

        /// <summary>
        /// 判断图案是否全部消除
        /// </summary>
        /// <returns></returns>
        bool IsFinishGame()
        {
            for (int i = 0; i < LinkList.numItems; i++)
            {
                if (LinkList.GetChildAt(i).visible)
                    return false;
            }
            return true;
        }

        void PlusScore()
        {
            currentScore++;
            scoreText.SetVar("score", currentScore.ToString()).FlushVars();
        }
    }

}