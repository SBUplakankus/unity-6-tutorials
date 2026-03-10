using UnityEngine;

namespace Patterns.Observer
{
    public class CameraController : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerHealth.OnPlayerDamaged += ShakeCamera;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerDamaged -= ShakeCamera;
        }
        
        public void ShakeCamera()
        {
            // Shake Camera
        }
    }
}
