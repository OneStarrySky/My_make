using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 角色界面
/// </summary>
public abstract class ICharacter
{
	protected string m_Name = "";               // 名称

	protected GameObject m_GameObject = null;   // 显示的Uniyt模型
	protected NavMeshAgent m_NavAgent = null;    // 控制角色移动使用
	protected AudioSource m_Audio = null;   //3D音频
	protected ParticleSystem particle = null; //特效

	protected string m_IconSpriteName = ""; // 显示Ico
	protected string m_AssetName = "";      // 模型名称
	protected int m_AttrID = 0;         // 使用的角色属性编号

	protected bool m_bKilled = false;           // 是否阵亡
	protected float m_RemoveTimer = 1.5f;       // 阵亡或多久移除
	protected bool m_bCanRemove = false;        // 是否可以移除

	protected ICharacterAttr m_Attribute = null;// 数值（运用到策略模式）

	//角色AI（运用状态模式）
	protected ICharacterAI m_AI = null;

	// 建造者
	public ICharacter() { }

	// 设定Unity模型
	public void SetGameObject(GameObject theGameObject)
	{
		m_GameObject = theGameObject;
		m_NavAgent = m_GameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
		m_NavAgent.enabled = true;
		//m_Audio = m_GameObject.GetComponent<AudioSource>();
	}

	// 取得Unity模型
	public GameObject GetGameObject()
	{
		return m_GameObject;
	}

	// 释放
	public virtual void Release()
	{
		if (m_GameObject != null)
			GameObject.Destroy(m_GameObject);
	}

	// 获得名称
	public string GetName()
	{
		return m_Name;
	}

	// 取得Asset名称
	public string GetAssetName()
	{
		return m_AssetName;
	}

	// 取得Icon名称
	public string GetIconSpriteName()
	{
		return m_IconSpriteName;
	}

	// 取得属性ID
	public int GetAttrID()
	{
		return m_AttrID;
	}


	// 取得角色名称
	public string GetCharacterName()
	{
		return m_Name;
	}

	// 更新
	public void Update()
	{
		if (m_bKilled)
		{
			m_RemoveTimer -= Time.deltaTime;
			if (m_RemoveTimer <= 0)
				m_bCanRemove = true;
		}
		UpdateAI();
	}

	#region AI
	// 設定AI
	public void SetAI(ICharacterAI CharacterAI)
	{
		m_AI = CharacterAI;
	}

	// 更新AI
	public void UpdateAI()
	{
		if (m_AI != null)
		{
			m_AI.Update(this);
		}
	}

	// 通知AI有角色被移除
	public void RemoveAITarget(ICharacter Targets)
	{
		m_AI.RemoveAITarget(Targets);
	}
	#endregion
	/// <summary>
	/// 攻击目标
	/// </summary>
	/// <param name="Target"></param>
	public void Attack(ICharacter Target)
	{

	}
	// 被其他角色攻擊
	public abstract void UnderAttack(ICharacter Attacker);

	#region 移动及位置	
	// 移动到目標
	public void MoveTo(Vector3 Position)
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(Position, out hit, 0, 5);
		Debug.LogError(hit.hit);
		if (m_NavAgent.Warp(Position))
		{
			m_NavAgent.isStopped = true;
			m_NavAgent.SetDestination(Position);
		}	
	}

	// 停止移动
	public void StopMove()
	{
		m_NavAgent.isStopped = false;
	}

	//  取得位置
	public Vector3 GetPosition()
	{
		return m_GameObject.transform.position;
	}
	#endregion

	#region 阵亡及移除

	// 是否阵亡
	public bool IsKilled()
	{
		return m_bKilled;
	}

	//  是否可以移除
	public bool CanRemove()
	{
		return m_bCanRemove;
	}
	#endregion

	#region 角色数值
	// 设定角色数值
	public virtual void SetCharacterAttr(ICharacterAttr CharacterAttr)
	{
		// 设定
		m_Attribute = CharacterAttr;
		m_Attribute.InitAttr();

		// 设定移动速度
		m_NavAgent.speed = m_Attribute.GetMoveSpeed();

		// 名称
		m_Name = m_Attribute.GetAttrName();
	}
	#endregion
}
