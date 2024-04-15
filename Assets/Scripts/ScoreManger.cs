using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, finalScoreText, finalfinalScoreText;
    [SerializeField] private Shop_Upgrades upgradesContainer;

    public int score = 0;
    public int finalScore = 0;
    public static ScoreManger instance;

    public int gargoyleCount = 0;

    public int impCount = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
        UpdateText(0);
    }

    public void UpdateText(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void GargoyleCount()
    {
        gargoyleCount++;
        if (gargoyleCount == 2)
        {
            score = score * 2;
            scoreText.text = this.score.ToString();
        }
    }

    public void Cthulhu()
    {
        score = score * 4;
        scoreText.text = this.score.ToString();
    }

    public void DemonLord()
    {
        score = score * 2;
        scoreText.text = this.score.ToString();
    }

    public void EndTurnCleanup()
    {
        gargoyleCount = 0;
        impCount = 0;

        finalScore += score;
        score = 0;

        scoreText.text = this.score.ToString();
        finalScoreText.text = this.finalScore.ToString();
        finalfinalScoreText.text = this.finalScore.ToString();
    }

    public void ImpCount()
    {
        impCount++;
        if (impCount == 3)
        {
            upgradesContainer.GuaranteeLesserDemon = true;
        }
        if (impCount == 5)
        {
            upgradesContainer.GuaranteeDemonLord = true;
        }
    }

}
