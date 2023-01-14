using UnityEngine;

namespace EnvironmentBehaviour
{
    public class HoverBehaviourScript : MonoBehaviour
    {
        public float xAmplitude = 0f;
        public float yAmplitude = 0f;
        public float zAmplitude = 0f;
        [Tooltip("Speed factor")] public float frequencyMultiplier = 1.0f;
        [Tooltip("Phase offset")] public float phaseModifier = 0f;
        private const float Pi = 3.1415f;
        private float _startTime = 0f;

        private Vector3 _origin;

        // Use this for initialization
        private void Start()
        {
            _origin = gameObject.transform.position;
            _startTime = Time.fixedTime;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            // ToDo: The phase modifier has to be some kind of normalized.
            var phaseValue = Mathf.Sin((Time.fixedTime - _startTime) * frequencyMultiplier + phaseModifier * (Pi / 2));
            gameObject.transform.position = new Vector3(
                _origin.x + phaseValue * xAmplitude,
                _origin.y + phaseValue * yAmplitude,
                _origin.z + phaseValue * zAmplitude
            );
        }
    }
}