using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField]
    public Color[] scoreColor;

     int colorIndex;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
       colorIndex = Random.Range(0, scoreColor.Length);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutione());
    }

    IEnumerator GameOverCoroutione()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.1f);
        gameOverPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<scoreManager>().bestScoreText.color = scoreColor[colorIndex] ;
        GetComponent<scoreManager>().currentScoreText.color =scoreColor[colorIndex];
        GetComponent<scoreManager>().best.color = scoreColor[colorIndex];
        

        yield break;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene("MM");
        Time.timeScale = 1.0f;
    }

    


}
