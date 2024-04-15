using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public static TurnController instance;
    [SerializeField] private List<TurnBar> turnBars;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndTurn()
    {
        if (turnBars.Count > 0)
        {
            turnBars[0].ActivateTurnBar();
            turnBars.RemoveAt(0);
        }
    }
}
