using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISceneState
{
	// 状态名称
	private SceneType m_StateName = SceneType.InitialScene;
	public SceneType StateName
	{
		get { return m_StateName; }
		set { m_StateName = value; }
	}
	/// <summary>
	/// 提供反射实例
	/// </summary>
	/// <returns></returns>
	public virtual ISceneState GetSceneState()
	{
		return this;
	}
	// 控制者
	protected SceneStateController m_Controller = null;

	// 建造者
	public ISceneState(SceneStateController Controller)
	{
		m_Controller = Controller;
	}

	// 开始
	public abstract void StateBegin();

	// 结束
	public abstract void StateEnd();

	// 更新
	public abstract void StateUpdate();

	public override string ToString()
	{
		return string.Format("[I_SceneState: StateName={0}]", StateName);
	}
}
