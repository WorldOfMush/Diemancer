using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : EffectSO
{
    private int soul = 1;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);
        ScoreManger.instance.ImpCount();
    }
}
