using System;
using UnityEngine;

namespace Car
{
    public class SimpleCar : MonoBehaviour
    {
        [Header("Steer")]
        [SerializeField] private float _maxSteer = 45f;
        [SerializeField] private Wheel[] _steerWheels = Array.Empty<Wheel>();

        [Header("Power")]
        [SerializeField] private float _power;
        [SerializeField] private Wheel[] _powerWheels = Array.Empty<Wheel>();

        [Header("Headlights")]
        [SerializeField] private Light[] _headLights = Array.Empty<Light>();
        [SerializeField] private float _lightsMaxPower = 1.5f;

        private bool _isCarRunning;

        void Update()
        {
            if (Input.GetButton("Vertical"))
            {
                _isCarRunning = true;
            }
            if (_isCarRunning)
            {
                Turning();
                Powering();
                TurningOnHeadlight();
            }
        }


        private void Turning()
        {
            foreach (var wheelCollider in _steerWheels)
            {
                wheelCollider.Steer(
                    Input.GetAxis("Horizontal")
                    * _maxSteer);
            }
        }


        private void Powering()
        {
            foreach (var powerWheel in _powerWheels)
            {
                powerWheel.Torque( 
                    Input.GetAxis("Vertical")
                    * _power
                    * Time.deltaTime);
            }
        }


        private void TurningOnHeadlight()
        {
            foreach (var headLights in _headLights)
            {
                headLights.intensity = _lightsMaxPower;
            }
        }
    }
}
