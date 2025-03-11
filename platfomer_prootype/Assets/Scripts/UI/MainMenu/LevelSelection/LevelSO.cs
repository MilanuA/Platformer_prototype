using UnityEngine;

namespace UI.MainMenu
{
    /// <summary>
    /// ScriptableObject is used here for "future" need. Could potentionally be used for managing if the level
    /// is unlocked, or was played before.
    /// </summary>
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Scriptable Objects/LevelSO")]
    public class LevelSO : ScriptableObject
    {
        public string LevelName;
        public SceneEnum Scene;
    }
}
