using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject playerObj;
    public float smoothTime = 0.1f;
    Vector2 velocity = Vector2.zero;

    public int yOffset;

    private void Update()
    {
        Vector3 targetPosition = playerObj.transform.TransformPoint(new Vector2(0, yOffset));
        if (targetPosition.y < transform.position.y) return;

        targetPosition = new Vector2(0, targetPosition.y);
        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
