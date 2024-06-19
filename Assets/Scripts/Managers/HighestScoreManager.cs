using UnityEngine;
using TMPro;

public class HighestScoreManager : MonoBehaviour
{
    public static HighestScoreManager instance;
    [SerializeField] private TMP_Text highestScoreDisplay;
    private int highestScore;
    private int currentScore;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        highestScore = PlayerPrefs.GetInt("HighestScore");
    }

    private void Update()
    {
        Debug.Log("Current Score: " + ScoreManager.instance.Getscore());
        Debug.Log("Highest Score: " + highestScore);
        highestScoreDisplay.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
    }

    public void HighestScoreUpdate()
    {
        currentScore = ScoreManager.instance.Getscore();
        // Update highest score if current score is greater
        if (currentScore > highestScore)
        {
            PlayerPrefs.SetInt("HighestScore", currentScore);
        }
    }

    public void ResetHighestScore()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
        highestScore = 0;
    }


}