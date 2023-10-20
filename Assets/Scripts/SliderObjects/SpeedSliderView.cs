using UnityEngine.UI;
using UnityEngine;

namespace Test.SliderUtilities
{
    [RequireComponent(typeof(Slider))]
    public class SpeedSliderView : MonoBehaviour
    {
        private Slider _slider;

        public Slider SliderComponent => _slider;
        
        public void Initialize()
        {
            _slider = GetComponent<Slider>();
        }
    }
}