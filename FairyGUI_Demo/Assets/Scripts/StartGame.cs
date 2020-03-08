using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class StartGame : MonoBehaviour
{
    Window linkWindow;
    // Start is called before the first frame update
    void Start()
    {

        UIPackage.AddPackage("UI/LinkGame");

        linkWindow = new LinkWindow();

        linkWindow.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
