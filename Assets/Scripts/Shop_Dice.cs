using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Dice : MonoBehaviour
{
    [SerializeField] private Transform shopDice;
    void Start()
    {
        StartShop();
    }

    public void StartShop()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        foreach (SO_DiceSide dice in DiceSideHolder.instance.current_dice_sides)
        {
            Transform diceT = Instantiate(shopDice, transform);
            diceT.GetComponent<Shop_DicePrefab>().CreateDice(dice);
        }
    }

}
