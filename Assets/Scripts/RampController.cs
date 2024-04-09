//using UnityEngine;

//public class RamptiltController : MonoBehaviour {
//    public LayerMask rampLayer;

//    void Update() {
//        RaycastHit hit;

//        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, rampLayer)) {
//            float tiltAngle = Vector3.Angle(Vector3.up, hit.normal);

//            transform.up = hit.normal;
//            Vector3 targetPosition = new Vector3(transform.position.x, hit.point.y + 2f, transform.position.z);
//            transform.position = targetPosition;

//        } else {
//            transform.up = Vector3.up;
//            Vector3 targetPosition = new Vector3(transform.position.x, 2f, transform.position.z);
//            transform.position = targetPosition;

//        }
//    }
//}