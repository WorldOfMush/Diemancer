using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frankenstein : EffectSO
{
    private int soul = 30;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);
    }
}
