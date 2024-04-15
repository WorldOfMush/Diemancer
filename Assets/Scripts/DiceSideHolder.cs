using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideHolder : MonoBehaviour
{
    public static DiceSideHolder instance;

    public SO_DiceSide[] all_dice_sides;

    public List<SO_DiceSide> current_dice_sides;

    public List<DiceStats> usableDice;

    [SerializeField] private Transform diceStats_prefab;
    [SerializeField] private List<Transform> instantiated_Dice;

    public List<SO_DiceSide> up_dice_sides;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        instantiated_Dice = new List<Transform>();
    }

}
