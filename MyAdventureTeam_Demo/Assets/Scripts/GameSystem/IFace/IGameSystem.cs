using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 游戏子系统共用界面
public abstract class IGameSystem
{
	protected GameManage m_GameManage = null;
	public IGameSystem(GameManage gameManage)
	{
		m_GameManage = gameManage;
	}
	/// <summary>
	/// 初始化
	/// </summary>
	public virtual void Initialize() { }
	/// <summary>
	/// 释放
	/// </summary>
	public virtual void Release() { }
}
