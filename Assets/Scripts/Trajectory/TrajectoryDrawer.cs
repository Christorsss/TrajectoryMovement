using UnityEngine;

namespace Test.Trajectory
{
    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryDrawer : MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        public void Initialize()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void IncrementLine(Vector3 position)
        {
            _lineRenderer.positionCount += 1;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, position);
        }

        public void FollowTarget(Vector3 targetPosition)
        {
            _lineRenderer.SetPosition(0, targetPosition);
        }

        public void RemoveFirstPoint()
        {
            if (_lineRenderer.positionCount > 0)
            {
                for (int i = 0; i < _lineRenderer.positionCount - 1; i++)
                {
                    _lineRenderer.SetPosition(i, _lineRenderer.GetPosition(i + 1));
                }
                _lineRenderer.positionCount--;
            }
        }
    }
}