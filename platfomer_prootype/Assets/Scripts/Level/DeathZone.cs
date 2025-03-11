using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
