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

    private void Update(){
        Debug.Log("Highest Score: " + highestScore);
        
    }

    public void HighestScoreUpdate(int currentScore)
    {
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            PlayerPrefs.SetInt("HighestScore", highestScore);
        }
        OnGUI();
    }

    public void ResetHighestScore()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
        highestScore = 0;
        OnGUI();
    }

    private void OnGUI()
    {
        highestScoreDisplay.text = highestScore.ToString();
    }

}