using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class sceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject aboutUs;

    [SerializeField]
    private Animator settingAnim;
    [SerializeField]
    bool isopenSetting = false;

    [SerializeField]
    private Animator howToPlayAnim;

    [SerializeField]
    GameObject howToPlay;

    public TextMeshProUGUI homeBestScore;

    [SerializeField]
    private Animator gameExitPanel;
    bool gameExitPanelShow = false;

    [SerializeField]
    GameObject exitpanel;

    googlePlayService GPS;
     int gamecount = 0;


    private void Start()
    {
        GPS = FindObjectOfType<googlePlayService>();
        settingAnim.SetBool("openSetting", false);
        aboutUs.SetActive(false);
        exitpanel.SetActive(false);
    }


    public void NoGameExit()
    {
        exitpanel.SetActive(true);
        gameExitPanelShow = false;
        gameExitPanel.SetBool("ShowGameOver", gameExitPanelShow);
    }

    public void GameExit()
    {
        exitpanel.SetActive(true);
        Application.Quit();
        Debug.Log("quit");
    }

    public void Play()
    {
        gamecount++;
        SceneManager.LoadScene("game");
        
    }

    private void Update()
    {
       
       

        homeBestScore.text = PlayerPrefs.GetInt("BestScore").ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitpanel.SetActive(true);
            gameExitPanelShow = true;
            gameExitPanel.SetBool("ShowGameOver", gameExitPanelShow);
        }

       
           
    }

    public void shopType()
    {
        Application.OpenURL("https://www.patreon.com/thegamerstudio");
    }

    public void howToPlayPressed()
    {
        howToPlay.SetActive(true);
        howToPlayAnim.SetBool("howToPlay",true);
        
    }

    public void close_howtoPlay()
    {
        howToPlayAnim.SetBool("howToPlay", false);
       // howToPlay.SetActive(false);
    }

    public void Rating()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.thegamerstudio.colorbounce");
    }

    public void himanshu()
    {
        Application.OpenURL("http://www.twitter.com/ht16998");
       
    }

    public void tarun()
    {
        Application.OpenURL("http://www.twitter.com/Tarun_Bisht11");
    }

    public void gaurav()
    {
        Application.OpenURL("http://www.twitter.com/golu_gt");
    }

    public void About()
    {
        aboutUs.SetActive(true);
    }
    public void AboutBack()
    {
        aboutUs.SetActive(false);
    }

    public void SettingPressed()
    {
        isopenSetting = !isopenSetting;
        settingAnim.SetBool("openSetting", isopenSetting);
    }
}
