using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneDragon : EffectSO
{
    private int soul = 50;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);
    }
}
