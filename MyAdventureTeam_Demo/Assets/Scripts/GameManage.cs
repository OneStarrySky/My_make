using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏管理类  运用外观模式
/// </summary>
public class GameManage
{
	// Singleton模版
	private static GameManage _instance;
	public static GameManage Instance
	{
		get
		{
			if (_instance == null)
				_instance = new GameManage();
			return _instance;
		}
	}

	private GameManage()
	{
		Initialize();
	}
	//场景状态
	private SceneType m_Scene = SceneType.InitialScene;
	public SceneType SceneName
	{
		get { return m_Scene; }
	}

	//ui管理类
	private UIManage m_manage = null;
	//场景管理类
	private SceneStateController m_SceneManage = null;
	public SceneStateController SceneManage
	{
		get { return m_SceneManage; }
	}

	//游戏系统
	private UIEventSystem uiEvent = null;//ui事件系统
	private StageSystem stageSystem = null;//关卡系统
	private CardManageSystem cardManage = null;//卡牌管理系统
	private AttackSystem attackSystem = null;//战斗管理系统

	//序列化
	private Serialize serialize = null;
    private Deserialization deserialization = null;

	/// <summary>
	/// 初始化
	/// </summary>
	private void Initialize()
	{
		//管理类单例
		m_manage = UIManage.Instance;
		m_SceneManage = SceneStateController.Instance;
		//系统
		uiEvent = new UIEventSystem(this);
		stageSystem = new StageSystem(this);
		cardManage = new CardManageSystem(this);
		attackSystem = new AttackSystem(this);
		//其他
		serialize = new Serialize(this);
		deserialization = Deserialization.Instance;
	}
	// 更新
	public void Update()
	{
		attackSystem.Updata();
	}

	public void AddAttackSystem(ICharacter character, bool flag = true)
	{
		if (flag)
		{
			attackSystem.AddCharacter(character);
		}
		else
		{
			attackSystem.AddCharacter(character);
		}
	}

	/// <summary>
	/// 保存角色数据
	/// </summary>
	public void SaveRoleData()
	{
		serialize.SaveRoleData();
	}

	/// <summary>
	/// 添加UI事件
	/// </summary>
	/// <param name="eventNmae"></param>
	/// <param name="u_Event"></param>
	public void AddUIEvent(UIEentName eventNmae, Action<Notification> u_Event)
	{
		uiEvent.AddEvent(eventNmae, u_Event);
	}
	/// <summary>
	/// 通知UI事件
	/// </summary>
	/// <param name="eventNmae"></param>
	/// <param name="notification"></param>
	public void Inform(UIEentName eventNmae, Notification notification = null)
	{
		uiEvent.Inform(eventNmae, notification);
	}
	/// <summary>
	/// 移除UI事件
	/// </summary>
	/// <param name="eventNmae"></param>
	public void RemovEvent(UIEentName eventNmae)
	{
		uiEvent.RemovEvent(eventNmae);
	}

}
