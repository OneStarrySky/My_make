using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleSelectBace : IUIBace
{
    public RoleSelectBace(UIType UIName) : base(UIName)
    {

    }
    public override void Initialize(UIType UIName)
    {
        base.Initialize(UIName);
        UnityTool.M_Debug("游戏选择角色界面UI");
        m_userModel = new RoleSelectModel(UIName);
        m_userView = new RoleSelectView(m_userModel, m_RootUI);
        m_userControl = new RoleSelectControl(m_userModel, m_userView);
    }
}
