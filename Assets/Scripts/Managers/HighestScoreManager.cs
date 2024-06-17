using UnityEngine;
using TMPro;

public class HighestScoreManager : MonoBehaviour
{
    public static HighestScoreManager instance;
    [SerializeField] private TMP_Text highestScoreDisplay;

    private int highestScore;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

    private void Update()
    {
        int currentScore = ScoreManager.instance.GetScore();
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            PlayerPrefs.SetInt("HighestScore", highestScore);
        }
        highestScoreDisplay.text = highestScore.ToString();
    }
}