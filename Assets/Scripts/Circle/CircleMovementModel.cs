namespace Test.Circle
{
    public class CircleMovementModel
    {
        private float _speed;

        public float CurrentSpeed => _speed;

        public CircleMovementModel(float speed)
        {
            _speed = speed;
        }

        public void ChangeSpeed(float newSpeed)
        {
            _speed = newSpeed;
        }
    }
}