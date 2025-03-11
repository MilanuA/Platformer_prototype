using System;
using TMPro;
using UnityEngine;

namespace UI.Level
{
    public class ScoreManager : MonoBehaviour
    {
        public static Action<int, int> OnUpdateScore; 
          
        [SerializeField] private TextMeshProUGUI scoreText;

        private int _currentScore;
        private int _maxScore;

        private void OnEnable()
        {
          OnUpdateScore += UpdateScore;
        }

        private void OnDisable()
        {
          OnUpdateScore -= UpdateScore;
        }

        /// <summary>
        /// Updates the score as well as score text
        /// </summary>
        /// <param name="current">Current score</param>
        /// <param name="max">Maximum score (in this case just maximum amount of collectables)</param>
        private void UpdateScore(int current, int max)
        { 
          _currentScore = current; 
          _maxScore = max; 
          scoreText.text = $"Score: {_currentScore} / {_maxScore}";
        }
        
    }
}
