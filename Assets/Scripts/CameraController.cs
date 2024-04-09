using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private Transform lookAt;

    [SerializeField]
    private float distance = 10.0f;

    [SerializeField]
    private bool follow3rd;

    void LateUpdate() {
        if (!follow3rd) {
            Vector3 Direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(10, 0, 0);
            transform.position = lookAt.position + rotation * Direction;

        } else {
            Vector3 direction = lookAt.forward * -distance;
            Vector3 targetPosition = lookAt.position + direction;
            targetPosition.y = lookAt.position.y + 5.0f;
            Quaternion rotation = Quaternion.Euler(10, 0, 0);

            transform.position = targetPosition;
            transform.rotation = rotation;
        }
        transform.LookAt(lookAt.position);
    }
}
