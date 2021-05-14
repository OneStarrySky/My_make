using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUserView
{
	private IUserModel model = null;
	public IUserModel Model
	{
		get { return model; }
	}
	private GameObject m_RootUI = null;
	/// <summary>
	/// 获取UI根节点
	/// </summary>
	public GameObject RootUI
	{
		get { return m_RootUI; }
	}

	public IUserView(IUserModel model, GameObject rootUI)
	{
		this.model = model;
		this.m_RootUI = rootUI;
		Initialize();
	}
	/// <summary>
	/// 初始化
	/// </summary>
	public abstract void Initialize();
	/// <summary>
	/// 释放
	/// </summary>
	public abstract void Release();
	/// <summary>
	/// 显示
	/// </summary>
	public virtual void Show()
	{
		Model.IsVisibl = true;
	}
	/// <summary>
	/// 隐藏
	/// </summary>
	public virtual void Hide()
	{
		Model.IsVisibl = false;
	}
}
