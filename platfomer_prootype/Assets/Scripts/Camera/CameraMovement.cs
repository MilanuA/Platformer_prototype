using System;
using UnityEngine;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform target; 
        [SerializeField] private float smoothSpeed = 5f;
        [SerializeField] private Vector3 offset;

        private void Awake()
        {
            if(!target)
               Debug.LogError("No target assigned!");
        }

        void LateUpdate()
        {
            if (!target) return;
            
            // camera follows the target (in this case the player)
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}