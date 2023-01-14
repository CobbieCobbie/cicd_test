using UnityEngine;

namespace EnvironmentBehaviour
{
    public class ScaleBehaviourScript : MonoBehaviour
    {
        public float xScale = 0.0f;
        public float yScale = 0.0f;
        public float zScale = 0.0f;

        [Tooltip("Speed factor")] public float frequencyMultiplier = 1.0f;

        private Vector3 _originalScale;


        // Use this for initialization
        private void Start()
        {
            _originalScale = gameObject.transform.localScale;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            gameObject.transform.localScale = new Vector3(
                _originalScale.x + Mathf.Cos(Time.fixedTime * frequencyMultiplier) * xScale,
                _originalScale.y + Mathf.Cos(Time.fixedTime * frequencyMultiplier) * yScale,
                _originalScale.z + Mathf.Cos(Time.fixedTime * frequencyMultiplier) * zScale
            );
        }
    }
}