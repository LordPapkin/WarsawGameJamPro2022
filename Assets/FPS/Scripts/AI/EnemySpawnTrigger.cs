using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class EnemySpawnTrigger : MonoBehaviour
    {
        [SerializeField] SpawnAnimation spawnAnimation;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && spawnAnimation != null)
                spawnAnimation.StartAnimation();
        }
    } 
}
