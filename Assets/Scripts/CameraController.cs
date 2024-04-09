using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private Transform lookAt;

    [SerializeField]
    public float distance = 10.0f;

    void LateUpdate() {
        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(10, 0, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);
    }
}
