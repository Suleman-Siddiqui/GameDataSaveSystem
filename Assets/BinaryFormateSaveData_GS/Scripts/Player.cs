using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GleamStudio.DataSaveBinaryFormat
{
    public class Player : MonoBehaviour
    {
        public int level = 3;
        public int health = 40;
        public Vector3 playerPosition;

        [SerializeField] private TMP_Text levelTMPText; 
        [SerializeField] private TMP_Text healthTMPText;
        
        
        
        public void SavePlayer()
        {
            DataSaveSystem.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            var playerData = DataSaveSystem.LoadPlayer();
            level = playerData.level;
            health = playerData.health;

            playerPosition = new Vector3(playerData.position[0], 
                playerData.position[1], playerData.position[2]);
            
            // show data
            levelTMPText.text = level.ToString();
            healthTMPText.text = health.ToString();
        }
        
        
        #region UI Methods

        public void ChangeLevel(int amount)
        {
            level += amount;
            levelTMPText.text = level.ToString();
        }

        public void ChangeHealth(int amount)
        {
            health += amount;
            healthTMPText.text = health.ToString();
        }

        #endregion
    }
}
