using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GleamStudio.DataSaveBinaryFormat
{
    [System.Serializable]
    public class PlayerData
    {
        public int level;
        public int health;
        public float[] position;

        public PlayerData(Player player)
        {
            this.level = player.level;
            this.health = player.health;
            position = new float[3];
            var playerPos = player.playerPosition;
            position[0] = playerPos.x;
            position[1] = playerPos.y;
            position[2] = playerPos.z;
            
        }
    }
}
