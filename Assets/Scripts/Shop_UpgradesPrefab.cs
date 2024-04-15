using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_UpgradesPrefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title, soul, description;
    [SerializeField] private Image sideImage;
    public Image outlineImage;

    private SO_DiceSide SO_diceside;


    public void CreateUpgrade(SO_DiceSide dice)
    {
        SO_diceside = dice;

        title.text = dice.side_name.ToUpper();
        
        if(dice.soul_power == 1)
        {
            soul.text = dice.soul_power.ToString() + " Soul";
        }
        else
        {
            soul.text = dice.soul_power.ToString() + " Souls";
        }

        description.text = dice.description.Replace("<nl>", "\n");

        sideImage.sprite = dice.side_image;
    }

    public SO_DiceSide GetDice()
    {
        return SO_diceside;
    }

    public void OnClickUpgrade()
    {
        if (Shop_Manager.instance.upgrade != this)
        {
            Shop_Manager.instance.SetUpgrade(this);
        }
        outlineImage.color = Color.white;
    }
}
