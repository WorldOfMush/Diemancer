using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserDemon : EffectSO
{
    private int soul = 10;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);
    }
}
