using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UI.Level
{
    public class LevelUI : MonoBehaviour
    {
        public static Action OnLevelFinished;

        [SerializeField] private TextMeshProUGUI levelDisplay;
        [SerializeField] private LevelFinished levelFinished;
        [Space(10)]
        [SerializeField] private SceneEnum nextLevelScene;
        public void ResetLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void Awake()
        {
            Time.timeScale = 1f;
        }
        
        private void Start()
        {
            string levelNumber = new string(SceneManager.GetActiveScene().name.Where(char.IsDigit).ToArray()); 

            levelDisplay.text = $"Level: {int.Parse(levelNumber):00}";
        }
        
        private void OnEnable()
        {
            OnLevelFinished += HandleLevelFinished;
        }

        private void OnDisable()
        {
            OnLevelFinished -= HandleLevelFinished;
        }

        private void HandleLevelFinished()
        {
            levelFinished.EnableLevelFinishScreen(nextLevelScene);
        }

        public void LoadNextLevel() =>  SceneManager.LoadScene(nextLevelScene.ToString());
    }
}
