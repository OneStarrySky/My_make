using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBace : IUIBace
{
    public TransitionBace(UIType UIName) : base(UIName)
    {

    }
    public override void Initialize(UIType UIName)
    {
        base.Initialize(UIName);
        UnityTool.M_Debug("过渡场景游戏UI");
        m_userModel = new TransitionModel(UIName);
        m_userView = new TransitionView(m_userModel, m_RootUI);
        m_userControl = new TransitionControl(m_userModel, m_userView);
    }
}
