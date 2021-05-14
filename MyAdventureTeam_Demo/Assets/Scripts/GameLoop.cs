using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏开始
/// </summary>
public class GameLoop : MonoBehaviour
{
    SceneStateController m_SceneStateController = null;
    //启动项
    GameManage gameManage = null;
    UIManage uIManage = null;
    private void Awake()
    {
        //初始挂载  不销毁
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameInit();
    }
    //启动项
    private void GameInit()
    {
         m_SceneStateController = SceneStateController.Instance;
         gameManage = GameManage.Instance;
         uIManage = UIManage.Instance;
    }

    void Start()
    {
        UnityTool.M_Debug("游戏初始挂载");
        
        //加载到一号场景
        m_SceneStateController.SetState(SceneType.RoleSelectScene, typeof(RoleSelectScene));
    }


    void Update()
    {
        m_SceneStateController.StateUpdate();
        gameManage.Update();
    }
}
