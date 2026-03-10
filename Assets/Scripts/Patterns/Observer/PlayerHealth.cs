using System;
using UnityEngine;

namespace Patterns.Observer
{
    public class PlayerHealth : MonoBehaviour
    {
        public static event Action OnPlayerDamaged;
        
        private int _currentHealth = 100;

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnPlayerDamaged?.Invoke();
        }
    }
}
