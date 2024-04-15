using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStats : MonoBehaviour
{
    public string side_name;
    public string creature_type;
    public string description;
    public int chance_to_spawn;
    public int soul_power;
    public Sprite side_image;

    public void SetFromSO(SO_DiceSide dice)
    {
        side_name = dice.side_name;
        creature_type = dice.creature_type;
        description = dice.description;
        chance_to_spawn = dice.chance_to_spawn;
        soul_power = dice.soul_power;
        side_image = dice.side_image;
    }

    public void ActivateDice()
    {
        print("Dice Activated");
    }
}
