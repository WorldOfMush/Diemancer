using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cthulhu : EffectSO
{
    public override void ActivateDice()
    {
        ScoreManger.instance.Cthulhu();
    }
}
