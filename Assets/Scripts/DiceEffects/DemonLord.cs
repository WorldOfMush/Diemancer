using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLord : EffectSO
{
    private int soul = 20;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);
        ScoreManger.instance.DemonLord();
    }
}
