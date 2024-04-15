using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{
    public static Shop_Manager instance;

    [SerializeField] private Canvas shopCanvas;
    [SerializeField] private Shop_DicePrefab dice;
    [SerializeField] private Shop_Upgrades UpgradeContainer;
    [SerializeField] private Shop_Dice DiceContainer;
    public Shop_UpgradesPrefab upgrade;
    private Transform hover;

    private void Awake()
    {
        shopCanvas.enabled = false;
        instance = this;
    }
    private void Start()
    {
        hover = GameObject.Find("HoverContainer").transform;
    }

    public void SetDice(Shop_DicePrefab diceObj)
    {
        if (upgrade != null)
        {
            dice = diceObj;
            DiceSideHolder.instance.current_dice_sides.Remove(dice.SO_diceSide);
            DiceSideHolder.instance.current_dice_sides.Add(upgrade.GetDice());
            dice.ChangeDice(upgrade.GetDice());
            ResetManager();
            StartCoroutine(CloseShop());
        }
    }

    public void ResetManager()
    {
        dice = null;
        UpgradeContainer.ClearContainer();
        upgrade = null;

        foreach(Transform t in hover)
        {
            Destroy(t.gameObject);
        }
    }

    public void SetUpgrade(Shop_UpgradesPrefab upgradeObj)
    {
        if (upgrade != null)
        {
            upgrade.outlineImage.color = Color.black;
        }

        upgrade = upgradeObj;
    }

    public void StartShop()
    {
        ResetManager();
        UpgradeContainer.StartShop();
        DiceContainer.StartShop();

    }

    private IEnumerator CloseShop()
    {
        yield return new WaitForSeconds(.5f);
        shopCanvas.enabled = false;

        DiceManager.instance.StartTurn();
    }
}
