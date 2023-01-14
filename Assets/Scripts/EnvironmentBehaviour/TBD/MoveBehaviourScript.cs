using UnityEngine;

public class MoveBehaviourScript : MonoBehaviour
{
    public bool loop;
    public bool randomizePhase;
    public Vector3 targetPosition;
    [Tooltip("Only if !Loop")] public float speed = 1.0f;

    private Vector3 _origin;
    private Vector3 _newPos;
    private Vector3 _dist;

    [Tooltip("Speed factor")] public float frequencyMultiplier = 1.0f;
    [Tooltip("Phase offset")] public float phaseModifier = 0f;
    private const float Pi = 3.1415f;


    private void Start()
    {
        _origin = transform.position;
        _newPos = targetPosition;
        _dist = targetPosition - _origin;

        if (randomizePhase) phaseModifier = Random.Range(-1f, 1f);
    }

    public void FixedUpdate()
    {
        if (loop)
        {
            var phaseValue = Mathf.Sin(Time.fixedTime * frequencyMultiplier + phaseModifier * (Pi / 2));
            transform.position = new Vector3(
                _origin.x + phaseValue * _dist.x,
                _origin.y + phaseValue * _dist.y,
                _origin.z + phaseValue * _dist.z
            );
        }
        else
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, _newPos, step);
        }
    }
}