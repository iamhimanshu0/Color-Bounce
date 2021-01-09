using UnityEngine;

public class RotationButton : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * rotationSpeed * Time.deltaTime);
    }

}
