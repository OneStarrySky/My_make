using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventListener : EventTrigger
{
    private Dictionary<EventTriggerType, Action<GameObject, BaseEventData>> map =
        new Dictionary<EventTriggerType, Action<GameObject, BaseEventData>>();

    public static EventListener Add(GameObject go)
    {
        EventListener tmp = go.GetComponent<EventListener>();
        if (tmp == null)
        {
            tmp = go.AddComponent<EventListener>();
        }
        return tmp;

    }

    /// <summary>
    /// 注册事件时调用
    /// </summary>
    /// <param name="eventType">事件类型</param>
    /// <param name="Callback"> lua侧的函数</param>
    public void AddListener(EventTriggerType eventType, Action<GameObject, BaseEventData> Callback)
    {
        if (map.ContainsKey(eventType))
        {
            map[eventType] += Callback;
        }
        else
        {
            map.Add(eventType, Callback);
        }
    }

    /// <summary>
    /// 移除注册事件
    /// </summary>
    /// <param name="eventType"></param>
    public void RemoveListener(EventTriggerType eventType)
    {
        if (map.ContainsKey(eventType))
        {
            map.Remove(eventType);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (map.ContainsKey(EventTriggerType.PointerClick))
        {
            map[EventTriggerType.PointerClick]?.Invoke(this.gameObject, eventData);
        }
    }
}
