using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnButtonManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText, rollText;
    [SerializeField] private SpriteRenderer buttonColor;

    [SerializeField] private Color rollColor, endTurnColor;



    public void ActivateButton(bool isEndTurn, int currentRoll, int maxRoll)
    {
        if (isEndTurn)
        {
            EndTurnButton(currentRoll, maxRoll);
        }
        else
        {
            RerollButton(currentRoll, maxRoll);
        }
    }

    private void EndTurnButton(int currentRoll, int maxRoll)
    {
        buttonColor.color = endTurnColor;
        buttonText.text = "END TURN";
        RerollText(currentRoll, maxRoll);
    }
    private void RerollButton(int currentRoll, int maxRoll)
    {
        buttonColor.color = rollColor;
        buttonText.text = "ROLL";
        RerollText(currentRoll, maxRoll);
    }
    private void RerollText(int currentRoll, int maxRoll)
    {
        rollText.text = currentRoll.ToString() + "/" + maxRoll.ToString();
    }
}
