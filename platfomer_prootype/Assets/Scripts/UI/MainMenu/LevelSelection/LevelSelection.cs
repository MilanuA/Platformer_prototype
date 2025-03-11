using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.MainMenu
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private List<LevelSO> levels;
        [SerializeField] private Transform levelsContainer;
        [SerializeField] private GameObject levelPrefab;
        
        private void Awake()
        {
            ShowLevels();
        }

        /// <summary>
        /// Instantiates buttons to the container and setups them
        /// </summary>
        private void ShowLevels()
        {
            foreach (LevelSO level in levels)
            {
                GameObject levelButton = Instantiate(levelPrefab, levelsContainer);
                levelButton.GetComponent<LevelSelectionButton>().Setup(level);
            }
        }
    }
}
