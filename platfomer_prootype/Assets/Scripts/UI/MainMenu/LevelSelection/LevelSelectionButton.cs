using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class LevelSelectionButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private UnityEngine.UI.Button button;
    
        /// <summary>
        /// Setups the button
        /// </summary>
        /// <param name="level">Scriptable object containing data about the level</param>
        public void Setup(LevelSO level)
        {
            buttonText.text = level.LevelName;
        
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => SceneManager.LoadScene(level.Scene.ToString()));
        }
    }
}
