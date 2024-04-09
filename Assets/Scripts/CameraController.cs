using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private Transform lookAt;

    [SerializeField]
    private float distance = 10.0f;

    void LateUpdate() {
        Vector3 Direction = new Vector3(0, 1f, -distance);
        Quaternion rotation = Quaternion.Euler(10, 0, 0);
        transform.position = lookAt.position + rotation * Direction;
        transform.LookAt(lookAt.position);
    }
}
