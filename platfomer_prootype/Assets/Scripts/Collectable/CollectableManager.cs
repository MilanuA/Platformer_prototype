using System;
using UI.Level;
using UnityEngine;

namespace Collectable
{
    public class CollectableManager : MonoBehaviour
    {
        /// <summary>
        /// Called when the new collectable is spawned
        /// </summary>
        public static Action OnCollectableSpawned;
        
        /// <summary>
        /// Called when the collectable is collected
        /// </summary>
        public static Action OnCollectableCollected;

        private int _maxCollectables;
        private int _collectedCollectables;

        private void OnEnable()
        {
            OnCollectableSpawned += IncreaseMaxCollectables;
            OnCollectableCollected += CollectableCollected;
        }

        private void OnDisable()
        {
            OnCollectableSpawned -= IncreaseMaxCollectables;
            OnCollectableCollected -= CollectableCollected;
        }

        private void IncreaseMaxCollectables()
        {
            _maxCollectables++;
            ScoreManager.OnUpdateScore?.Invoke(_collectedCollectables, _maxCollectables);
        }

        /// <summary>
        /// Handles collecting the collectable
        /// </summary>
        private void CollectableCollected()
        {
            _collectedCollectables++;
            
            //update score
            ScoreManager.OnUpdateScore?.Invoke(_collectedCollectables, _maxCollectables);
            
            //if we collected all the collectables, level is finished
            if (_collectedCollectables == _maxCollectables)
                LevelUI.OnLevelFinished?.Invoke();
        }
    }
}
