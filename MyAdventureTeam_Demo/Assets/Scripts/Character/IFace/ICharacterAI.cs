﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色AI
/// </summary>
public abstract class ICharacterAI
{
	protected ICharacter m_Character = null;
	protected float m_AttackRange = 2;
	protected IAIState m_AIState = null;//AI状态

	protected const float ATTACK_COOLD_DOWN = 1f; // 攻击的CoolDown（冷却）
	protected float m_CoolDown = ATTACK_COOLD_DOWN;

	public ICharacterAI(ICharacter Character)
	{
		m_Character = Character;
	}

	// 更换AI状态
	public virtual void ChangeAIState(IAIState NewAIState)
	{
		m_AIState = NewAIState;
		m_AIState.SetCharacterAI(this);
	}

	// 攻击目标
	public virtual void Attack(ICharacter Target)
	{
		// 时间到了才攻击
		m_CoolDown -= Time.deltaTime;
		if (m_CoolDown > 0)
			return;
		m_CoolDown = ATTACK_COOLD_DOWN;

		m_Character.Attack(Target);
	}

	// 是否在攻击距离內
	public bool TargetInAttackRange(ICharacter Target)
	{
		float dist = Vector3.Distance(m_Character.GetPosition(),
									   Target.GetPosition());
		return (dist <= m_AttackRange);
	}

	// 目前的位置
	public Vector3 GetPosition()
	{
		return m_Character.GetGameObject().transform.position;
	}

	// 移动
	public void MoveTo(Vector3 Position)
	{
		m_Character.MoveTo(Position);
	}

	// 停止移动
	public void StopMove()
	{
		m_Character.StopMove();
	}

	// 是否阵亡
	public bool IsKilled()
	{
		return m_Character.IsKilled();
	}

	// 目标移除
	public void RemoveAITarget(ICharacter Target)
	{
		m_AIState.RemoveTarget(Target);
	}

	// 更新AI
	public void Update(ICharacter Target)
	{
		if (m_AIState != null)
		{
			m_AIState.Update(Target);
		}
	}

	// 是否可以攻击Heart
	public abstract bool CanAttackHeart();

}
