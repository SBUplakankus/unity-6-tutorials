using UnityEngine;

namespace Patterns.Observer
{
    public class AudioController : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerHealth.OnPlayerDamaged += PlayHitSound;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerDamaged -= PlayHitSound;
        }
        
        public void PlayHitSound()
        {
            
        }
    }
}
