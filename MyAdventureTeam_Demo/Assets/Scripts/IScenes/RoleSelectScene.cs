using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 人物选择场景
/// </summary>
public class RoleSelectScene : ISceneState
{
	public RoleSelectScene(SceneStateController Controller) : base(Controller)
	{
		UnityTool.M_Debug("游戏人物选择场景");
		this.StateName = SceneType.RoleSelectScene;
	}


	// 开始
	public override void StateBegin()
	{
		UIManage.Instance.AddUI(UIType.RoleSelectUI, typeof(RoleSelectBace));
		UIManage.Instance.Show(UIType.RoleSelectUI);
	}

	// 结束
	public override void StateEnd()
	{
		UIManage.Instance.Hide(UIType.RoleSelectUI);
		UIManage.Instance.RemoveUI(UIType.RoleSelectUI);
	}

	// 更新
	public override void StateUpdate()
	{
		 
	}
}

