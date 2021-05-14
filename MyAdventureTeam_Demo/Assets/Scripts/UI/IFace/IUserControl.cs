using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 游戏使用者界面
public abstract class IUserControl
{
	protected IUserModel m_UserModel = null;
	protected IUserView m_UserView = null;

	public IUserControl(IUserModel userModel, IUserView userView)
	{
		this.m_UserModel = userModel;
		this.m_UserView = userView;
	}

	public UIType UIName
	{
		get { return m_UserModel.UIName; }
	}

	public bool IsVisible()
	{
		return m_UserModel.IsVisibl;
	}

	public virtual void Show()
	{
		m_UserView.Show();
	}

	public virtual void Hide()
	{
		m_UserView.Hide();
	}
	/// <summary>
	/// 初始化
	/// </summary>
	public virtual void Initialize() 
	{
		Hide();
	}

	public virtual void Release() 
	{
		m_UserModel.Release();
		m_UserModel = null;
		m_UserView.Release();
		m_UserView = null;
	}
	public virtual void Update() { }
}
