using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelectControl : IUserControl
{
	private RoleSelectModel Model
	{
		get { return (RoleSelectModel)m_UserModel; }
	}
	private RoleSelectView View
	{
		get { return (RoleSelectView)m_UserView; }
	}
	public RoleSelectControl(IUserModel userModel, IUserView userView) : base(userModel, userView)
	{
		Initialize();
	}

	// 初始
	public override void Initialize()
	{
		base.Initialize();
	}
	public override void Show()
	{
		base.Show();
	}

	public override void Hide()
	{
		base.Hide();
	}
	// 更新
	public override void Update()
	{

	}

	//释放
	public override void Release()
	{
		base.Release();
	}

}
