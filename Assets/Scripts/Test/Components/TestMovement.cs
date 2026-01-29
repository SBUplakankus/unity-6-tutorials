
using Enums;
using Interfaces;
using Systems;
using UnityEngine;

namespace Test.Components
{
    public class TestMovement : MonoBehaviour, IUpdateable
    {
        private void Move()
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        private void OnEnable() => GameUpdateManager.Instance.Register(this, UpdatePriority.High);
        private void OnDisable() => GameUpdateManager.Instance.Unregister(this);

        public void OnUpdate(float deltaTime)
        {
            Move();
        }
    }
}
