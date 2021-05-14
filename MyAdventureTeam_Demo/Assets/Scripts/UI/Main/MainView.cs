using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : IUserView
{
    public MainView(IUserModel model, GameObject rootUI) : base(model, rootUI) { }

    Button but_system = null;

    public override void Initialize()
    {
        but_system = UnityTool.FindChildComponent<Button>(RootUI, "but_system");
        if (but_system != null)
        {
            but_system.onClick.AddListener(() =>
            {
                UnityTool.M_Debug("打开设置UI");
            });
        }
    }

    public override void Release()
    {
        
    }
}
