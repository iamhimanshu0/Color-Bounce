using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class googlePlayService : MonoBehaviour {

    [SerializeField]
    Button LoginButton;

    [SerializeField]
    GameObject loginFirst;

    private void Awake()
    {
        if (loginFirst == null)
            return;
        else
            loginFirst.SetActive(false);

        if (LoginButton == null)
        {
            return;
        }

        PlayGamesPlatform.Activate();
        OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
        
        if(!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            LoginButton.interactable = true;
        }
        else
        {
            LoginButton.interactable = false;
        }
    }

    //Google Play Servies
    public void OnConnectClick()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            OnConnectionResponse(success);
        });
    }

    private void OnConnectionResponse(bool authenticate)
    {
        if(authenticate)
        {
            AchievementUnlock(CBGPS.achievement_sign_in);
            Debug.Log("Connected");
            LoginButton.interactable = false;

        }
        else
        {
            LoginButton.interactable = true;
            Debug.Log("Sorry problem Occur " + authenticate);
        }
    }


    public void AchievementUnlock(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) =>
          {
              Debug.Log("Unlocked Achievement");
          });
    }

    public void OnAchievementUnlock()
    {
        if(Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            loginFirst.SetActive(true);
        }
    }

    public void OnLeadBoardClick()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            loginFirst.SetActive(true);
        }
    }

    public void ReportScore(int score)
    {
        Social.ReportScore(score, CBGPS.leaderboard_highscore, (bool success) =>
          {
             // Debug.Log("LeadBoard HighScore Access");
          });
    }

   public void close_notLoaded()
    {
        loginFirst.SetActive(false);
    }

}
