using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    int currentScore = 0;
    public TextMeshProUGUI best;

    googlePlayService GPS;

    private void Start()
    {
        GPS = FindObjectOfType<googlePlayService>();
        SetbestScore();
    }

    private void Update()
    {
        if (currentScore >= PlayerPrefs.GetInt("BestScore", 0))
        {
            bestScoreText.text = currentScore.ToString();
            // SetbestScore();
            PlayerPrefs.SetInt("BestScore", currentScore);
            GPS.ReportScore(currentScore);
        }
    }

    void SetbestScore()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", currentScore).ToString();
    }

   

    public void addScore(int score)
    {
        currentScore += score;
        currentScoreText.text = currentScore.ToString();
       
        
        //google play
   
       GPS.ReportScore(score);

        
        //google Play 
        switch (currentScore)
        {
            case 50:
                GPS.AchievementUnlock(CBGPS.achievement_50_point);
                break;
            case 75:
                GPS.AchievementUnlock(CBGPS.achievement_75_point);
                break;
            case 100:
                GPS.AchievementUnlock(CBGPS.achievement_100_score);
                break;
            case 125:
                GPS.AchievementUnlock(CBGPS.achievement_125__points);
                break;
            case 150:
                GPS.AchievementUnlock(CBGPS.achievement_150_score);
                break;
           case 500:
                GPS.AchievementUnlock(CBGPS.achievement_500_points);
                break;
            default:
                break;
        }
        //google play
       
      
    }


}


