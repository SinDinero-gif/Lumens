using UnityEngine;

namespace Managers
{
    public class CameraChange : MonoBehaviour
    {
        public Transform playerTransform;
        public float smoothSpeed = 10f;

        private void LateUpdate()
        {
            var position = playerTransform.position;
            Vector3 desiredPosition = new Vector3(position.x, position.y, -10f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,  smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}