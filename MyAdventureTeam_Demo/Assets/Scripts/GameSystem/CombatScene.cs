using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScene : ISceneState
{
    public CombatScene(SceneStateController Controller) : base(Controller)
    {
        UnityTool.M_Debug("关卡主场景");
        this.StateName = SceneType.CombatScene;
    }
    CharacterFactory factory = new CharacterFactory();
    public override void StateBegin()
    {
        CardData card = Deserialization.Instance.CardDatas[0];
        ICharacter character = factory.CreateSoldier(card , Vector3.one);
        GameManage.Instance.AddAttackSystem(character);
    }

    public override void StateEnd()
    {
        
    }

    public override void StateUpdate()
    {
        
    }
}
