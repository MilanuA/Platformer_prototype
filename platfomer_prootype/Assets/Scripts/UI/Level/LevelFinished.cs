using System;
using TMPro;
using UnityEngine;

namespace UI.Level
{
    public class LevelFinished : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private GameObject levelFinishScreen;
        
        /// <summary>
        /// Enables the "level finish" screen
        /// </summary>
        /// <param name="nextScene">What is the next sceen</param>
        public void EnableLevelFinishScreen(SceneEnum nextScene)
        {
            Time.timeScale = 0;

            levelFinishScreen.SetActive(true);
            
            if(nextScene == SceneEnum.MainMenu)
                buttonText.text = "Go to menu";
            
        }
    }
}
