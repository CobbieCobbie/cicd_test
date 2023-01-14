using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base class for the player object, keeping its current stats 
/// as well as the collider logic.
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public class Player : MonoBehaviour
{
    public int level;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Start called");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: " + collision.gameObject.name);

        if (collision.gameObject.name == "BoundaryColliderLeft")
        {
            AudioManager.instance.Play("Sonar");
        } else if (collision.gameObject.name == "BoundaryColliderRight")
        {
            AudioManager.instance.Play("Sonar");
        }
    }
}
