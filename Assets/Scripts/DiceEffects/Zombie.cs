using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EffectSO
{
    [SerializeField] private SO_DiceSide humanSO;
    [SerializeField] private SO_DiceSide zombieSO;
    private int soul = 2;
    public override void ActivateDice()
    {
        ScoreManger.instance.UpdateText(soul);
    }

    public override void EndTurnEffect()
    {
        foreach(SO_DiceSide dice in DiceSideHolder.instance.current_dice_sides)
        {
            if(dice == humanSO)
            {
                DiceSideHolder.instance.current_dice_sides.Remove(dice);
                DiceSideHolder.instance.current_dice_sides.Add(zombieSO);
                return;
            }
        }
    }
}
