using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dice Side", menuName = "Dice Side")]
public class SO_DiceSide : ScriptableObject
{
    public string side_name;
    public string creature_type;
    public string description;
    public int chance_to_spawn;
    public int soul_power;
    public Sprite side_image;
    public GameObject gameObjectForEffect;
}
