using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI状态
/// </summary>
public abstract class IAIState
{
	protected ICharacterAI m_CharacterAI = null; // 角色AI(状态拥有者）

	public IAIState()
	{ }

	// 设定CharacterAI的对象
	public void SetCharacterAI(ICharacterAI CharacterAI)
	{
		m_CharacterAI = CharacterAI;
	}

	// 设定目标
	public virtual void SetAttackPosition(Vector3 AttackPosition)
	{ }

	// 更新
	public abstract void Update(ICharacter Targets);

	// 目标被移除
	public virtual void RemoveTarget(ICharacter Target)
	{ }
}
