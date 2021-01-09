using UnityEngine;

public class stairManager : MonoBehaviour
{
    public GameObject stairPrefab;
    int stairIndex = 0;

    float stairWidth = 4f;
    float stairHeight = 1f;

    float hue;

    private void Start()
    {
        InitColor();
        for (int i = 0; i < 2; i++)
        {
            MakeNewStair();
        }
    }

    void InitColor()
    {
        hue = Random.Range(0, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hue, 0.6f, 0.8f);
    }

    public void MakeNewStair()
    {
        int randomPositionX;
        if (stairIndex == 0)
            randomPositionX = 0;
        else
            randomPositionX = Random.Range(-3, 3);

        Vector2 newPosition = new Vector2(randomPositionX, stairIndex * 5);
        GameObject newStair = Instantiate(stairPrefab, newPosition, Quaternion.identity);
        newStair.transform.SetParent(transform);
        newStair.transform.localScale = new Vector2(stairWidth, stairHeight);

        setColor(newStair);
        
        stairIndex++;

        DecreaseStairWidth();
    }

    void DecreaseStairWidth()
    {
        stairWidth -= 0.01f;
        if (stairWidth <= 1f) stairWidth = 1f;
      
    }

    void setColor(GameObject newStair)
    {
        if(Random.Range(0,3)!=0)
        {
            hue += 0.11f;
            if(hue>=1)
            {
                hue -= 1;
            }
        }
        newStair.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, 0.6f, 0.8f);
    }

}
