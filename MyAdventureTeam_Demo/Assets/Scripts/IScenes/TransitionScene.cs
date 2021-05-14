using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// 游戏过渡场景
/// </summary>
public class TransitionScene : ISceneState
{
	public TransitionScene(SceneStateController Controller) : base(Controller)
	{
		UnityTool.M_Debug("游戏过渡场景");
		this.StateName = SceneType.TransitionScene;
	}
	//加载进度
	private float m_progress;
	public void Progress(float progress)
	{
		m_progress = progress;
		UIManage.Instance.Show(UIType.TransitionUI);
	}

	// 开始
	public override void StateBegin()
	{
		m_progress = 0;
		UIManage.Instance.AddUI(UIType.TransitionUI, typeof(TransitionBace));
	}

	// 结束
	public override void StateEnd()
	{
		m_progress = 0;
		UIManage.Instance.Hide(UIType.TransitionUI);
	}

	// 更新
	public override void StateUpdate()
	{

	}
}
