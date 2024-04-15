using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Upgrades : MonoBehaviour
{
    [SerializeField] private Transform shopUpgrades;

    //private int count = 0;

    [SerializeField] private List<SO_DiceSide> all_dice_sides;
    public bool GuaranteeLesserDemon = false;
    public bool GuaranteeDemonLord = false;

    [SerializeField] private SO_DiceSide lesserDemon, demonLord;

    void Start()
    {
        ResetList();

        SpawnUpgrades();
    }

    public void StartShop()
    {
        ClearContainer();
        SpawnUpgrades();
    }

    private void SpawnUpgrades()
    {
        ResetList();

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        int randomInt = Random.Range(0, all_dice_sides.Count);
        int chanceToSpawn = all_dice_sides[randomInt].chance_to_spawn;
        int randomChance = Random.Range(0, 100);

        for (int i = 0; i < 3; i++)
        {
            if (GuaranteeLesserDemon)
            {
                GuaranteeLesserDemon = false;
                Transform tr = Instantiate(shopUpgrades, transform);
                tr.GetComponent<Shop_UpgradesPrefab>().CreateUpgrade(lesserDemon);
                continue;
            }
            if (GuaranteeDemonLord)
            {
                GuaranteeDemonLord = false;
                Transform tr = Instantiate(shopUpgrades, transform);
                tr.GetComponent<Shop_UpgradesPrefab>().CreateUpgrade(demonLord);
                continue;
            }

            randomInt = Random.Range(0, all_dice_sides.Count);
            chanceToSpawn = all_dice_sides[randomInt].chance_to_spawn;
            randomChance = Random.Range(0, 100);

            while (chanceToSpawn < randomChance)
            {
                randomInt = Random.Range(0, all_dice_sides.Count);
                chanceToSpawn = all_dice_sides[randomInt].chance_to_spawn;
                randomChance = Random.Range(0, 100);
            }

            Transform t = Instantiate(shopUpgrades, transform);
            t.GetComponent<Shop_UpgradesPrefab>().CreateUpgrade(all_dice_sides[randomInt]);

            all_dice_sides.Remove(all_dice_sides[randomInt]);
        }
    }

    private void ResetList()
    {

        all_dice_sides = new List<SO_DiceSide>();

        for (int i = 0; i < DiceSideHolder.instance.all_dice_sides.Length; i++)
        {
            all_dice_sides.Add(DiceSideHolder.instance.all_dice_sides[i]);
        }
    }

    public void ClearContainer()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }

}
