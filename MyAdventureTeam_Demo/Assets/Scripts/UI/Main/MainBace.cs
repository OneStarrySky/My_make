using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBace : IUIBace
{
    public MainBace(UIType UIName):base(UIName)
    {

    }
    public override void Initialize(UIType UIName)
    {
        base.Initialize(UIName);
        UnityTool.M_Debug("游戏主界面UI");
        m_userModel = new MainModel(UIName);
        m_userView = new MainView(m_userModel, m_RootUI);
        m_userControl = new MainControl(m_userModel, m_userView);
    }
}
