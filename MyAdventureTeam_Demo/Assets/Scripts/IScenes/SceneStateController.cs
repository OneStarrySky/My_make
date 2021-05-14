using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景控制类
/// </summary>
public class SceneStateController
{
	private Dictionary<SceneType, ISceneState> m_Scenes = new Dictionary<SceneType, ISceneState>();
	private ISceneState m_State;
	//过渡场景
	public TransitionScene m_transitionScene = null;
	//判断场景是否为加载状态
	private bool m_bRunBegin = false;

	private static SceneStateController _instance;
	public static SceneStateController Instance
	{
		get
		{
			if (_instance == null)
				_instance = new SceneStateController();
			return _instance;
		}
	}
	public SceneStateController()
	{
		Init();
	}
	/// <summary>
	/// 初始化
	/// </summary>
	private void Init()
	{
		//初始化时就加载过渡场景
		TransitionScene scene = new TransitionScene(this);
		m_transitionScene = scene;
	}

	/// <summary>
	/// 场景是否已加载
	/// </summary>
	/// <param name="LoadSceneName"></param>
	/// <returns></returns>
	public bool IsLoadSceneName(SceneType LoadSceneName)
	{
		return m_Scenes.ContainsKey(LoadSceneName);
	}

	/// <summary>
	/// 移除注册场景
	/// </summary>
	/// <param name="SceneName"></param>
	public void RemoveScene(SceneType SceneName)
	{
		if (IsLoadSceneName(SceneName))
		{
			m_Scenes[SceneName].StateEnd();
			m_Scenes.Remove(SceneName);
		}
	}

	/// <summary>
	/// 切换场景
	/// </summary>
	/// <param name="LoadSceneName"></param>
	public void SetState(SceneType LoadSceneName ,Type type)
	{
		// 加载场景
		SetScene(LoadSceneName);

		//是否存在场景
		if (IsLoadSceneName(LoadSceneName))
		{
			m_State = m_Scenes[LoadSceneName];
			return;
		}

		//加载场景
		ISceneState scenes = null;
		object obj2 = Activator.CreateInstance(type, this);//动态创建实例
		if (obj2 is ISceneState)
		{
			scenes = ((ISceneState)obj2).GetSceneState();
			m_State = scenes;
			m_Scenes[LoadSceneName] = scenes;
		}
	}

	/// <summary>
	/// 加载场景
	/// </summary>
	/// <param name="LoadSceneName"></param>
	private void SetScene(SceneType LoadSceneName)
	{
		UnityTool.M_Debug("状态场景切换");
		//加载过渡场景
		m_transitionScene.StateBegin();
		SceneManager.LoadScene(SceneType.TransitionScene.ToString());

		m_bRunBegin = false;
		// 异步加载场景
		AsyncLoadScene(LoadSceneName.ToString());

		// 前一个场景结束
		if (m_State != null)
			m_State.StateEnd();
	}

	//协程加载场景
	private AsyncOperation async = null;
	private void AsyncLoadScene(string LoadSceneName)
	{
		if (LoadSceneName == null || LoadSceneName.Length == 0)
			return;
		async = SceneManager.LoadSceneAsync(LoadSceneName);
	}

	// 更新
	public void StateUpdate()
	{
		// 是否加载完成
		if (async != null && !async.isDone)
		{
			m_transitionScene.Progress(async.progress);	
			return;
		}
	
		// 通知新的State开始
		if (m_bRunBegin == false && m_State != null)
		{
			if (async != null && async.isDone)
			{
				m_transitionScene.StateEnd();
				async = null;
			}
			m_State.StateBegin();
			m_bRunBegin = true;
		}

		if (m_bRunBegin = true && m_State != null)
		{
			m_State.StateUpdate();
		}
	}
}

/// <summary>
/// 场景状态类型
/// </summary>
public enum SceneType
{
	InitialScene = -1,
	TransitionScene,
	RoleSelectScene,
	MainSecene,
	CombatScene
}