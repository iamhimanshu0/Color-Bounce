using UnityEngine;



public class soundManager : MonoBehaviour {

    [SerializeField]
    AudioSource GameMusic;
    [SerializeField]
    AudioSource oldCityTheme;
    
   

    public void MusicPlay()
    {
        GameMusic.volume = 0.4f;
        //GameMusic.pitch = 1.23f;
        oldCityTheme.volume =1f;

    }

    public void MusicStop()
    {
        GameMusic.volume = 0;
        oldCityTheme.volume = 0;

    }
   
   


}
