using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;

public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;
    [SerializeField] private Canvas shopCanvas;
    [SerializeField] private Canvas endGameCanvas;
    public List<Dice> all_active_dice;
    [SerializeField] private TurnButtonManager turnButtonManager;
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI turnScoreText, finalScoreText;

    private int maxRerolls = 3;
    private int currentRerolls;
    private int turn;
    private int finalScore;
    private int turnScore;

    private bool onTurn = false;

    private bool endGame = false;

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

        //all_active_dice = new List<Dice>();

        currentRerolls = 0;
    }
    private void Start()
    {
        /*foreach (GameObject dice in GameObject.FindGameObjectsWithTag("Dice"))
        {
            all_active_dice.Add(dice.GetComponent<Dice>());
        }*/

        endGameCanvas.enabled = false;
        StartTurn();
    }

    private void Update()
    {
        if (onTurn)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivateButton();
            }
            if (CanRoll())
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    all_active_dice[4].FreezeDice();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    all_active_dice[3].FreezeDice();
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    all_active_dice[2].FreezeDice();
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    all_active_dice[1].FreezeDice();
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    all_active_dice[0].FreezeDice();
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.CircleCast(GetMouseWorldPosition(), .1f, Vector2.zero, float.MaxValue, hitLayerMask);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.TryGetComponent<Dice>(out Dice dice))
                    {
                        if (dice != null)
                        {
                            dice.FreezeDice();
                        }
                    }
                    else if (hit.collider.gameObject.TryGetComponent<TurnButtonManager>(out TurnButtonManager turnButtonManager))
                    {
                        ActivateButton();
                    }
                    else
                    {
                        EndTurn();
                    }
                }
            }
        }
    }

    private IEnumerator activateDice()
    {
        float waitTime = .1f;
        for (int i = all_active_dice.Count - 1; i >= 0; i--)
        {
            if (!all_active_dice[i].GetIsFrozen())
            {
                all_active_dice[i].ActivateDice();
                yield return new WaitForSeconds(waitTime);
            }
            else yield return null;
        }
    }

    private bool CanRoll()
    {
        foreach(Dice dice in all_active_dice)
        {
            if (!dice.canRoll)
            {
                return false;
            }
        }
        return true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        return mousePosition;
    }

    private void ActivateButton()
    {
        if (!CanRoll()) return;

        if (currentRerolls < maxRerolls)
        {
            StartCoroutine(activateDice());
            currentRerolls++;

            if (currentRerolls < maxRerolls)
            {
                turnButtonManager.ActivateButton(false, currentRerolls, maxRerolls);
            }
            else
            {
                turnButtonManager.ActivateButton(true, currentRerolls, maxRerolls);
            }
        }
        else
        {
            EndTurn();
        }
    }

    private void EndTurn()
    {
        if (!CanRoll()) return;

        onTurn = false;

        if (turn == 10)
        {
            endGame = true;
        }

        TurnController.instance.EndTurn();
        RotateSign.instance.StartAnimation();

        foreach (Dice dice in all_active_dice)
        {
            dice.ResetDice();
        }

        StartCoroutine(DiceEffects());


    }

    private IEnumerator DiceEffects()
    {
        float waitTime = .25f;
        for (int i = all_active_dice.Count - 1; i >= 0; i--)
        {
            if (!all_active_dice[i].GetIsFrozen())
            {
                all_active_dice[i].ActivateSO();
                yield return new WaitForSeconds(waitTime);
            }
            else yield return null;
        }
        ScoreManger.instance.EndTurnCleanup();
        StartCoroutine(ShopPhase());
    }

    private void CalculateScore()
    {
        turnScore = ScoreManger.instance.score;
        ScoreManger.instance.EndTurnCleanup();
        finalScore += turnScore;
        turnScoreText.text = turnScore.ToString();
        finalScoreText.text = finalScore.ToString();

    }

    public void StartTurn()
    {
        onTurn = true;
        StartCoroutine(activateDice());
        currentRerolls = 0;
        turnButtonManager.ActivateButton(false, currentRerolls, maxRerolls);
        turn++;
    }

    private IEnumerator ShopPhase()
    {
        for (int i = all_active_dice.Count - 1; i >= 0; i--)
        {
            all_active_dice[i].EndTurnEffectSO();
        }
        yield return new WaitForSeconds(1);
        if (endGame)
        {
            endGameCanvas.enabled = true;
        }
        else
        {
            shopCanvas.enabled = true;
            Shop_Manager.instance.StartShop();
        }


    }
}
