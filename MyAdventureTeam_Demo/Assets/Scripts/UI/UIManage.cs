using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage
{
	// Singleton模版
	private static UIManage _instance;
	public static UIManage Instance
	{
		get
		{
			if (_instance == null)
				_instance = new UIManage();
			return _instance;
		}
	}
	private UIManage()
	{
		Initialize();
	}

	//Canvas
	public GameObject m_Canvas = null;
	private Dictionary<UIType, IUIBace> m_DataPool = new Dictionary<UIType, IUIBace>();
	private IUIBace m_current = null;


	/// <summary>
	/// 初始化
	/// </summary>
	private void Initialize()
	{
		m_Canvas = UnityTool.FindGameObject("Canvas");
	}
	//获得UI
	public IUIBace GetUI(UIType uIType)
	{
		if (m_DataPool.ContainsKey(uIType))
		{
			return m_DataPool[uIType];
		}
		return null;
	}
	//查找UI物体
	public GameObject FindUI(UIType uIType)
	{
		return m_Canvas.transform.Find(uIType.ToString()).gameObject;
	}
	//是否存在UI类
	public bool ISExist(UIType uIType)
	{
		return m_DataPool.ContainsKey(uIType);
	}

	//添加
	public void AddUI(UIType uIType, Type type)
	{
		//如果存在则结束
		if (m_DataPool.ContainsKey(uIType))
		{
			return;
		}
		//通过反射实例对象
		IUIBace user = null;
		object obj2 = Activator.CreateInstance(type, uIType);//动态创建实例
		if (obj2 is IUIBace)
		{
			user = ((IUIBace)obj2).GetUserInterface();
			m_DataPool[uIType] = user;
			user = null;
		}

		UnityTool.M_Debug("加载UI");
	}

	//移除
	public void RemoveUI(UIType uIType)
	{
		if (m_DataPool.ContainsKey(uIType))
		{
			m_DataPool[uIType].Release();
			m_DataPool.Remove(uIType);
		}
	}

	//显示
	public void Show(UIType uIType)
	{
		if (m_DataPool.ContainsKey(uIType))
		{
			m_DataPool[uIType].Show();
			m_current = m_DataPool[uIType];
			UnityTool.M_Debug("显示" + uIType.ToString());
		}
	}

	//关闭
	public void Hide(UIType uIType)
	{
		if (m_DataPool.ContainsKey(uIType))
		{
			m_DataPool[uIType].Hide();
			UnityTool.M_Debug("关闭" + uIType.ToString());
		}
	}

	// 更新
	public void Update()
	{
		if (m_current != null)
		{
			m_current.Update();
		}
	}

	//释放
	public void Release()
	{
		foreach(var item in m_DataPool)
		{
			item.Value.Release();
		}
		m_DataPool = null;
	}
}

/// <summary>
/// ui枚举类型
/// </summary>
public enum UIType
{
	Floor = -1,
	CombatUI,
	TransitionUI,
	RoleSelectUI,
	MainUI,
}