using System;
using UnityEngine;

namespace Test.Circle
{
    public class CircleView : MonoBehaviour
    {
        private const float _DESTINATION_TRASHOLD = 0.01f;
        private const float _DEFAULT_START_SPEED = 5;

        public Action OnReachedDestination;

        private CircleMovementModel _movementModel;

        public void Initialize()
        {
            _movementModel = new CircleMovementModel(_DEFAULT_START_SPEED);
        }

        public void MoveTo(Vector2 pos)
        {
            if(Vector2.Distance(pos, this.transform.position) <= _DESTINATION_TRASHOLD)
            {
                OnReachedDestination?.Invoke();
                return;
            }
            else
            {
                this.transform.position += (Vector3)(pos - (Vector2)this.transform.position).normalized * _movementModel.CurrentSpeed * Time.deltaTime;
            }
        }

        public void ChangeMovementSpeed(float speed)
        {
            _movementModel.ChangeSpeed(speed);
        }
    }
}