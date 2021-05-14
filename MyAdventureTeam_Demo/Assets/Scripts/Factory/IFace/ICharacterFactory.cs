using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterFactory
{
	// 建立Soldier
	public abstract Soldier CreateSoldier(CardData cardData, Vector3 SpawnPosition);

}
