using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop_DicePrefab : MonoBehaviour
{
    [SerializeField] private Transform upgrades_prefab;
    private Transform activeUpgrade;

    [SerializeField] private Image sideImage;
    public SO_DiceSide SO_diceSide;
    public void CreateDice(SO_DiceSide dice)
    {
        SO_diceSide = dice;
        sideImage.sprite = dice.side_image;
    }

    public void OnHoverEnter()
    {
        activeUpgrade = Instantiate(upgrades_prefab, GameObject.Find("HoverContainer").transform);
        activeUpgrade.GetComponent<Shop_UpgradesPrefab>().CreateUpgrade(SO_diceSide);
    }

    public void OnHoverExit()
    {
        if (activeUpgrade != null)
        {
            Destroy(activeUpgrade.gameObject);
        }
        activeUpgrade = null;
    }

    public void ChangeDice(SO_DiceSide dice)
    {
        CreateDice(dice);
    }

    public void OnDiceClick()
    {
        if(Shop_Manager.instance.upgrade != null)
        {
            Shop_Manager.instance.SetDice(this);
        }
    }
}
