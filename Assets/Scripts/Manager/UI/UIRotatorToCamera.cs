using UnityEngine;

public class UIRotatorToCamera : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
}
