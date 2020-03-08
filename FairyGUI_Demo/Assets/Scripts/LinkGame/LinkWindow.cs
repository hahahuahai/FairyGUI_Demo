using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class LinkWindow : Window
{
    GList LinkList;

    GButton firstClick = new GButton();
    GButton secondClick = new GButton();
    bool isFirstClicked = true; // 判断玩家是否第一次点击

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
        LinkList.numItems = 12;
        LinkList.onClickItem.Add(OnLinkListClicked);
    }

    void RenderListItem(int index, GObject obj)
    {
        GButton button = (GButton)obj;
        button.icon = "Pics/" + "i" + index / 2;
        button.title = "i" + index / 2;
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
        if(firstClick.title == secondClick.title)//两次点击的图片一致
        {
            firstClick.visible = false;
            secondClick.visible = false;
        }

    }
}
