using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 游戏主场景
/// </summary>
public class MainSecene : ISceneState
{
	public MainSecene(SceneStateController Controller) : base(Controller)
	{
		UnityTool.M_Debug("游戏主场景");
		this.StateName = SceneType.MainSecene;
	}


	// 开始
	public override void StateBegin()
	{
		UIManage.Instance.AddUI(UIType.MainUI, typeof(MainBace));
		UIManage.Instance.Show(UIType.MainUI);
		GameObject scenery = UnityTool.FindGameObject("scenery");
		foreach(Transform item in scenery.transform)
		{
			EventListener.Add(item.gameObject)
				.AddListener(EventTriggerType.PointerClick, ClickCustom);
		}
	}
	private void ClickCustom(GameObject game, BaseEventData baseEvent)
	{
		switch (game.name)
		{
			case "customsPass":
				SceneStateController.Instance.SetState(SceneType.CombatScene, typeof(CombatScene));
				break;
			case "cardUpgrade":
				UnityTool.M_Debug("卡牌升级界面");
				break;
			case "role":
				UnityTool.M_Debug("人物属性界面");
				break;
			case "stop":
				UnityTool.M_Debug("商城");
				break;
			case "cardBag":
				UnityTool.M_Debug("卡包");
				break;
		}
	}
	// 结束
	public override void StateEnd()
	{
		UIManage.Instance.Hide(UIType.MainUI);
	}

	// 更新
	public override void StateUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		}
	}
}
