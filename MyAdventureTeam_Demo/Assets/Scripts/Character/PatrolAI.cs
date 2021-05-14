using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : IAIState
{
    private float time = 0;
    public override void Update(ICharacter Target)
    {
        time += Time.deltaTime;
        if(time >= 5)
        {
            Target.MoveTo(new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
            time = 0;
        }
    }
}
