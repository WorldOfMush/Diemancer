using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyles : EffectSO
{
    private int soul = 15;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);

        ScoreManger.instance.GargoyleCount();

    }
}
