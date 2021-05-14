using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI事件系统
/// </summary>
public class UIEventSystem : IGameSystem
{
    private Dictionary<UIEentName, Action<Notification>> m_event = null;

    public UIEventSystem(GameManage gameManage) : base(gameManage)
    {
        m_event = new Dictionary<UIEentName, Action<Notification>>();
    }
    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="eventNmae"></param>
    /// <param name="u_Event"></param>
    public void AddEvent(UIEentName eventNmae, Action<Notification> u_Event)
    {
        if (m_event.ContainsKey(eventNmae))
        {
            m_event[eventNmae] += u_Event;
        }
        m_event.Add(eventNmae, u_Event);
    }
    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="eventNmae"></param>
    public void RemovEvent(UIEentName eventNmae)
    {
        if (m_event.ContainsKey(eventNmae))
        {
            m_event.Remove(eventNmae);
        }
    }
    /// <summary>
    /// 通知事件
    /// </summary>
    /// <param name="eventNmae"></param>
    /// <param name="notification"></param>
    public void Inform(UIEentName eventNmae, Notification notification = null)
    {
        if (!m_event.ContainsKey(eventNmae))
        {
            UnityTool.M_Debug("未注册UI事件");
            return;
        }
        m_event[eventNmae](notification);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Release()
    {
        m_event.Clear();
        base.Release();
    }
}
