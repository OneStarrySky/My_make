using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 切换场景过渡UI界面
public class TransitionControl : IUserControl
{
	private TransitionModel Model
	{
		get { return (TransitionModel)m_UserModel; }
	}
	private TransitionView View
	{
		get { return (TransitionView)m_UserView; }
	}
	//构造
	public TransitionControl(IUserModel userModel, IUserView userView) : base(userModel, userView)
	{
		Initialize();
	}

	public void Progress(float progress)
	{
		View.Progress(progress);
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
