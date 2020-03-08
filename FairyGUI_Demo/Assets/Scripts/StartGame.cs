using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace FairyGuiDemo
{

    public class StartGame : MonoBehaviour
    {
        Window linkWindow;
        // Start is called before the first frame update
        void Start()
        {
            PackageManager.inst.AddAllPackages();

            linkWindow = new LinkWindow();

            linkWindow.Show();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
