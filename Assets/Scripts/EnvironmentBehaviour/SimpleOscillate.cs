using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sample movement class. 
/// Note: Make sure to set the BodyType to "kinematic" if you're using a rigidbody.
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public class SimpleOscillate : MonoBehaviour
{
    public float Amplitude = 12.0f;
    public float Speed = 1.0f;

    private Vector3 _startPosition;
    private float _startTime;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        _startTime = Time.time;

        // Note: We want to make sure, that the correct rigidbody body type is used.
        // If we e.g. use the dynamic one, this script modifies stuff that is otherwise modified by the physics engine
        var rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            if (rigidbody2D.bodyType != RigidbodyType2D.Kinematic)
            {
                Debug.LogError("Please make sure to use the Kinematic rigidbody body type to prevent issues.");
            }
        }
        var rigidbody3D = GetComponent<Rigidbody>();
        if (rigidbody3D != null)
        {
            if (!rigidbody3D.isKinematic)
            {
                Debug.LogError("Please make sure to flag the used rigidbody as kinematic to prevent issues.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _startPosition + (Vector3.left * Amplitude * Mathf.Sin((Time.time - _startTime) * Speed));
    }
}
