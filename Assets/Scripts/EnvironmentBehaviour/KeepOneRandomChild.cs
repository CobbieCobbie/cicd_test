using UnityEngine;

namespace EnvironmentBehaviour
{
    public class KeepOneRandomChild : MonoBehaviour
    {
        private void Start()
        {
            var randomPick = Random.Range(0, transform.childCount);

            for (var i = 0; i < transform.childCount; i++)
            {
                if (i != randomPick)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}