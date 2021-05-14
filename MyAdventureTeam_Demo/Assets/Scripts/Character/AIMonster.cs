using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMonster : ICharacterAI
{
    public AIMonster(ICharacter Character):base(Character)
    {

    }
    public override bool CanAttackHeart()
    {
        return false;
    }
}
