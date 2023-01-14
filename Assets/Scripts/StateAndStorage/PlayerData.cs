using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The base data class for saving the current player state.
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    // Note: As a replacement for Vector3, because Vector3 could not be serialized
    public float[] position;

    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;

        var playerPosition = player.GetPlayerPosition();
        position = new float[3];
        position[0] = playerPosition.x;
        position[1] = playerPosition.y;
        position[2] = playerPosition.z;
    }
}
