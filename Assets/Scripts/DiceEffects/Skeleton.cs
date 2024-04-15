using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EffectSO 
{
    [SerializeField] private SO_DiceSide skeletonSO;
    private int soul = 0;
    public override void ActivateDice()
    {
        foreach(Dice dice in DiceManager.instance.all_active_dice)
        {
            if(dice.currentSO == skeletonSO)
            {
                soul++;
            }
        }
        ScoreManger.instance.UpdateText(soul);
        soul = 0;
    }
}
