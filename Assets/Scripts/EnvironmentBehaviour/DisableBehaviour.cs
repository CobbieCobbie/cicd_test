using System.Collections;
using UnityEngine;

namespace EnvironmentBehaviour
{
    public class DisableBehaviour : MonoBehaviour
    {
        public float secondsToWait = 0;

        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(WaitAndDeactivate());
        }

        // Disables a game object after a given interval
        private IEnumerator WaitAndDeactivate()
        {
            yield return new WaitForSeconds(secondsToWait);
            gameObject.SetActive(false);
        }
    }
}