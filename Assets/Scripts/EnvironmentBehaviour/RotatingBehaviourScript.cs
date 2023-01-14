using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnvironmentBehaviour
{
    public class RotatingBehaviourScript : MonoBehaviour
    {
        [Tooltip("Enable of axis")] public bool xAxis, yAxis, zAxis;

        [Tooltip("Degrees per second")]
        public float degreesPerSecond = 20f;
        [Tooltip("Inverse direction")]
        public bool inverse = false;

        [Tooltip("Random phase enabled")] public bool randomPhaseEnabled;
        [Tooltip("Phase offset")]
        [Range(0f, 2f)]
        public float phaseShifter = 0f;

        [Tooltip("Enable seesaw instead of complete rotation")]
        public bool seesaw = false;

        [Tooltip("Seesaw range in degrees")] public float seesawDegreeRange = 360f;


        [Space(10)] public bool useLocalRotation = true;

        private const float Pi = (float) Math.PI;
        private Vector3 _initialRotation;
        private float _startTime = 0f;

        private void Start()
        {
            // Persist initial setup
            _initialRotation = (useLocalRotation)
                ? gameObject.transform.localRotation.eulerAngles
                : gameObject.transform.rotation.eulerAngles;
            _startTime = Time.fixedTime;

            if (randomPhaseEnabled)
            {
                phaseShifter = Random.Range(0f, 2f);
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            var dirSpeed = (inverse) ? degreesPerSecond * -1f : degreesPerSecond;
            var time = Time.fixedTime - _startTime;

            if (seesaw)
            {
                var rotation = Mathf.Cos(time * dirSpeed / 20 + phaseShifter * Pi) * seesawDegreeRange;
                if (useLocalRotation)
                {
                    gameObject.transform.localRotation = Quaternion.Euler(_initialRotation.x + (xAxis ? rotation : 0),
                        _initialRotation.y + (yAxis ? rotation : 0),
                        _initialRotation.z + (zAxis ? rotation : 0));
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Euler(_initialRotation.x + (xAxis ? rotation : 0),
                        _initialRotation.y + (yAxis ? rotation : 0),
                        _initialRotation.z + (zAxis ? rotation : 0));
                }
            }
            else
            {
                var rotation = time * dirSpeed + phaseShifter * 180;
                if (useLocalRotation)
                {
                    gameObject.transform.localRotation = Quaternion.Euler(_initialRotation.x + (xAxis ? rotation : 0),
                        _initialRotation.y + (yAxis ? rotation : 0),
                        _initialRotation.z + (zAxis ? rotation : 0));
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Euler(_initialRotation.x + (xAxis ? rotation : 0),
                        _initialRotation.y + (yAxis ? rotation : 0),
                        _initialRotation.z + (zAxis ? rotation : 0));
                }
            }
        }
    }
}