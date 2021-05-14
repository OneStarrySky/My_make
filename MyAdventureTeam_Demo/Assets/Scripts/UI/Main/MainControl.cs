using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : IUserControl
{
	private MainModel Model
	{
		get { return (MainModel)m_UserModel; }
	}
	private MainView View
	{
		get { return (MainView)m_UserView; }
	}

	public MainControl(IUserModel userModel, IUserView userView):base(userModel, userView)
	{
		Initialize();
	}

	public override void Show()
	{
		base.Show();
	}

	public override void Hide()
	{
		base.Hide();
	}
}
