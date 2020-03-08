using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System.IO;
using System;

namespace FairyGuiDemo
{
    /// <summary>
    /// FGUI包管理
    /// </summary>
    public class PackageManager
    {
        #region 单例
        static PackageManager _inst;
        public static PackageManager inst
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
                _inst = new PackageManager();
            }
        }
        private PackageManager() { }
        #endregion

        const string UiPath = "Assets/Resources/UI";
        const string UiPackagePath = "UI/";
        /// <summary>
        /// 获取所有UI包名
        /// </summary>
        /// <returns></returns>
        protected List<string> GetAllUiPackageNames()
        {
            List<string> names = new List<string>();
            if (Directory.Exists(UiPath))
            {
                DirectoryInfo directoryinfo = new DirectoryInfo(UiPath);
                FileInfo[] files = directoryinfo.GetFiles("*", SearchOption.AllDirectories);
                Debug.Log("files.Length:" + files.Length);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith(".meta"))
                    {
                        continue;
                    }
                    if (files[i].Name.Contains("_fui.bytes"))
                    {
                        Debug.Log("Name:" + files[i].Name);
                        string[] sArray = files[i].Name.Split(new string[] { "_fui.bytes" }, StringSplitOptions.RemoveEmptyEntries);
                        Debug.Log("sArray[0]:" + sArray[0]);
                        if (!names.Contains(sArray[0]))
                            names.Add(sArray[0]);
                    }
                }
            }
            return names;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddAllPackages()
        {
            List<string> UiPackageNames = GetAllUiPackageNames();

            foreach (var name in UiPackageNames)
            {
                UIPackage.AddPackage(UiPackagePath + name);
            }
        }
        

    }

}
