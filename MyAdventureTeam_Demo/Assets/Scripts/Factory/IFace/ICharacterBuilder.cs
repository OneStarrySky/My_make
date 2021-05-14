using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建立角色时所需的参数
/// </summary>
public abstract class ICharacterBuildParam
{
	public Soldier NewCharacter = null;//角色
	public Vector3 SpawnPosition;//位置
}

/// <summary>
/// 界面用来生成ICharacter的各零件
/// </summary>
public abstract class ICharacterBuilder
{
	// 设定建立参数
	public abstract void SetBuildParam(ICharacterBuildParam theParam);
	// 载入Asset中的角色模型
	public abstract void LoadAssetGameObject();
	// 加入OnClickScript
	public abstract void AddOnClickScript();
	// 加入AI
	public abstract void AddAI();
	// 设定角色能力
	public abstract void SetCharacterAttr();
	// 加入管理器
	public abstract void AddCharacterSystem(GameManage gameManage);
}