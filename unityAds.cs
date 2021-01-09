using UnityEngine;
using UnityEngine.Advertisements;


public class unityAds : MonoBehaviour {

    public static unityAds Instance { set; get; }

    [SerializeField]
    public GameObject notloaded;

    private void Start()
    {
        Instance = this;
        

        DontDestroyOnLoad(gameObject);

       //MobileAds.Initialize(appId);
    }

    public void ShowIntersitialAds()
    {
        if (Advertisement.IsReady("IntersitialAds"))
        {
            // var options = new ShowOptions { resultCallback = HandleShowResult };
            //Advertisement.Show("IntersitialAds", options);
            Advertisement.Show();
        }
       

    }

  public void ShowVideoAds()
    {
        if(Advertisement.IsReady("video"))
        {
            Advertisement.Show();
        }
       
    }

   
}
