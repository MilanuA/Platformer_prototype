using System.Collections;
using Audio;
using UnityEngine;

namespace Collectable
{
    public class LevelCollectable : MonoBehaviour, ICollectable
    {
        [Min(0)]
        [Tooltip("After the collectable is collected, how much will overall score increase by")]
        [SerializeField] private int scoreIncrease;

        private void Start()
        {
            CollectableManager.OnCollectableSpawned?.Invoke();
        }

        public void Collect()
        {
           StartCoroutine(CollectCoroutine());
        }

        IEnumerator CollectCoroutine()
        {
            AudioSourceManager.OnPlayCollectAudio?.Invoke();
            //small delay for the audio to finish playing
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
            CollectableManager.OnCollectableCollected?.Invoke();
        }
    }
}
