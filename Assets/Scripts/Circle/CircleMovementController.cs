using Test.SliderUtilities;
using Test.Trajectory;
using Test.Utilities;
using UnityEngine;

namespace Test.Circle
{
    public class CircleMovementController : MonoBehaviour
    {
        [SerializeField] private CircleView _circleObject;

        private MouseRegistrer _mouseRegistrer;
        private TrajectoryDrawer _trajectoryDrawer;
        private MovePointsList _movePoints;
        private SpeedSliderView _speedSlider;

        public void Initialize(MouseRegistrer mouseRegistrer, TrajectoryDrawer trajectoryDrawer, SpeedSliderView speedSlider)
        {
            _trajectoryDrawer = trajectoryDrawer;
            _mouseRegistrer = mouseRegistrer;
            _speedSlider = speedSlider;

            _circleObject.Initialize();
            _movePoints = new MovePointsList();
            _speedSlider.SliderComponent.value = _circleObject.Speed;

            SubscribeEvents();
        }

        private void Update()
        {
            if (_movePoints.HasMovePoints)
            {
                _circleObject.MoveTo(_movePoints.CurrentMovePosition);
                _trajectoryDrawer.FollowTarget(_circleObject.transform.position);
            }
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _mouseRegistrer.OnMouseClick += _movePoints.AddMovePosition;
            _circleObject.OnReachedDestination += _movePoints.ClearFirstPoint;
            _circleObject.OnReachedDestination += _trajectoryDrawer.RemoveFirstPoint;
            _mouseRegistrer.OnMouseClick += _trajectoryDrawer.IncrementLine;

            _speedSlider.SliderComponent.onValueChanged.AddListener(_circleObject.ChangeMovementSpeed);
        }

        private void UnsubscribeEvents()
        {
            _mouseRegistrer.OnMouseClick -= _movePoints.AddMovePosition;
            _circleObject.OnReachedDestination -= _movePoints.ClearFirstPoint;
            _circleObject.OnReachedDestination -= _trajectoryDrawer.RemoveFirstPoint;
            _mouseRegistrer.OnMouseClick -= _trajectoryDrawer.IncrementLine;
        }
    }
}