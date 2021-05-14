using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUserModel
{
	private bool m_bActive = true;
	private UIType m_UIName = UIType.Floor;

	public IUserModel(UIType UIName)
	{
		m_UIName = UIName;
	}

	/// <summary>
	/// 获取UI类型
	/// </summary>
	public UIType UIName
	{
		get { return m_UIName; }
	}
	/// <summary>
	/// 设置 获取 显隐
	/// </summary>
	public bool IsVisibl
	{
		get { return m_bActive; }
		set
		{
			m_bActive = value;
		}
	}
	/// <summary>
	/// 初始化
	/// </summary>
	public abstract void Initialize();
	/// <summary>
	/// 释放
	/// </summary>
	public abstract void Release();
}
