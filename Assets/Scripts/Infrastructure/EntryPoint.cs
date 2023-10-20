using Test.Circle;
using Test.SliderUtilities;
using Test.Trajectory;
using Test.Utilities;
using UnityEngine;

namespace Test.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private MouseRegistrer _mouseRegistrer;
        [SerializeField] private CircleMovementController _circleMovement;
        [SerializeField] private TrajectoryDrawer _trajectoryDrawer;
        [SerializeField] private SpeedSliderView _speedSlider;

        private void Awake() => Init();

        private void Init()
        {
            _speedSlider.Initialize();
            _trajectoryDrawer.Initialize();
            _mouseRegistrer.Initialize();

            _circleMovement.Initialize(_mouseRegistrer, _trajectoryDrawer, _speedSlider);
        }
    }
}