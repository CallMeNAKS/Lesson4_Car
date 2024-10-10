using UnityEngine;

namespace Car
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private WheelCollider _wheelCollider;
        [SerializeField] private Transform _visual;
        [SerializeField] private Vector3 _baseVisual = Vector3.up;

        [SerializeField] private bool _isBackWheel;

        private void Update()
        {
            _wheelCollider.GetWorldPose(out _, out var quaternion);
            _visual.rotation = quaternion;
            _visual.Rotate(_baseVisual);
        }


        public void Steer(float angle)
        {
            if (_isBackWheel)
            {
                _wheelCollider.steerAngle = -angle;
            }
            else
            {
                _wheelCollider.steerAngle = angle;
            }
        }


        public void Torque(float power)
        {
            _wheelCollider.motorTorque = power;
        }
    }
}
