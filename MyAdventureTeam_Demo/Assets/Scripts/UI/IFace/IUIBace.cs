using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUIBace
{
    protected GameObject m_RootUI = null;
    protected IUserControl m_userControl = null;
    protected IUserModel m_userModel = null;
    protected IUserView m_userView = null;

    public IUIBace(UIType UIName)
    {
        Initialize(UIName);
    }

    public virtual void Initialize(UIType UIName)
    {
        GameObject temp = LoadAsset.Instance.LoadResources<GameObject>(LoadAssetType.UI, UIName.ToString());
        m_RootUI = GameObject.Instantiate(temp, UIManage.Instance.m_Canvas.transform, false);
    }

    /// <summary>
    /// 提供反射实例
    /// </summary>
    /// <returns></returns>
    public IUIBace GetUserInterface()
    {
        return this;
    }

    /// <summary>
	/// 显示
	/// </summary>
	public void Show()
    {
        if (m_RootUI == null)
        {
            return;
        }
        m_RootUI.SetActive(true);
        m_userView.Show();
    }

    /// <summary>
    /// 隐藏
    /// </summary>
    public void Hide()
    {
        if (m_RootUI == null)
        {
            return;
        }
        m_RootUI.SetActive(false);
        m_userView.Hide();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// 释放
    /// </summary>
    public virtual void Release()
    {
        m_userControl.Release();
        m_userModel.Release();
        m_userView.Release();
        GameObject.Destroy(m_RootUI);
    }
}
