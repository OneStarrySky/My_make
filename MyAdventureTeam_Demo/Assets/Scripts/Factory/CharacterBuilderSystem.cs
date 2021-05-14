using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 利用Builder界面來建筑物件
/// </summary>
public class CharacterBuilderSystem : IGameSystem
{
	private int m_GameObjectID = 0;

	public CharacterBuilderSystem(GameManage gameManage) : base(gameManage)
	{ }

	public override void Initialize()
	{ }


	// 建立 
	public void Construct(ICharacterBuilder theBuilder)
	{
		// 利用Builder产生各部份加入Product中
		theBuilder.LoadAssetGameObject();
		theBuilder.AddOnClickScript();
		theBuilder.SetCharacterAttr();
		theBuilder.AddAI();

		// 加入管理器內
		theBuilder.AddCharacterSystem(m_GameManage);
	}
}
