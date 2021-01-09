using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stair : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 targetPosition;

    float randomFloat;
    float smoothTime=0.1f;
    Vector2 velocity = Vector2.zero;

    private void Start()
    {
        targetPosition = transform.position;
        if(Random.Range(0,2)==0)
        {
            randomFloat = -10;
        }else
        {
            randomFloat = 10;
        }

        startPosition = new Vector2(targetPosition.x + randomFloat, targetPosition.y);
        transform.position = startPosition;
    }

    private void Update()
    {
        if (Vector2.Distance(targetPosition, transform.position) > 0.01f)
        {
            MoveToTargetPosition();
        }
    }

    void MoveToTargetPosition()
    {
        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


}
