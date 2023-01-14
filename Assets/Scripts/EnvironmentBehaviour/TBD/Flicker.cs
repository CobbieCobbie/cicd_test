using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnvironmentBehaviour
{
    public class Flicker : MonoBehaviour
    {
        [Range(0f, 10f)] public float minimumStableTime = 1;
        [Range(0f, 10f)] public float maximumStableTime = 2;
        
        // Specifies the object to be flickered
        public GameObject whatToFlicker;
        
        
        // Specifies the warning lights which are disabled at first
        // and start secondsWarningLightsAreShown seconds before the cam starts
        [Range(0f, 10f)] public float secondsWarningLightsAreShown;
        public GameObject[] warningLights;

        private void Start()
        {
            maximumStableTime = Math.Max(minimumStableTime, maximumStableTime);
            
            foreach (var warningLight in warningLights)
            {
                warningLight.SetActive(false);
            }
            
            StartCoroutine(FlickerNext());
        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private IEnumerator FlickerNext()
        {
            // Show warning lights...
            foreach (var warningLight in warningLights)
            {
                warningLight.SetActive(true);
            }
            // ...wait...
            yield return new WaitForSeconds(secondsWarningLightsAreShown);
            // ...and deactivate the warning lights
            foreach (var warningLight in warningLights)
            {
                warningLight.SetActive(false);
            }
            
            // Set the game object active
            whatToFlicker.SetActive(true);
            // ...wait...
            yield return new WaitForSeconds(Random.Range(minimumStableTime, maximumStableTime));
            // ...and disable it again
            whatToFlicker.SetActive(true);
            
            // Finally, start over
            StartCoroutine(FlickerNext());
        }
    }
}