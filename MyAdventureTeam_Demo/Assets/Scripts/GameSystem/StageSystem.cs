using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 关卡控制系统
public class StageSystem : IGameSystem
{
	private int m_NowStageLv = 1;   // 目前的关卡
	private IStageHandler m_NowStageHandler = null;//当前节点
	private IStageHandler m_MaxStageHandler = null;//可以到达节点
	private IStageHandler m_RootStageHandler = null;//根节点

	private Vector3 m_AttackPos = Vector3.zero; // 攻击点
	private bool m_bCreateStage = false;        // 是否需要建立关卡

	public StageSystem(GameManage gameManage) : base(gameManage)
	{
		Initialize();
	}

	public override void Initialize()
	{

	}

	// 释放
	public override void Release()
	{
		base.Release();

		m_AttackPos = Vector3.zero;
	}

	// 通知新的关卡
	private void NotiyfNewStage()
	{
		

	}

	// 取得攻击点
	private Vector3 GetAttackPosition()
	{

		return m_AttackPos;
	}
}
