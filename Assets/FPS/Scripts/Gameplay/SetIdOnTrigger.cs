using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class SetIdOnTrigger : MonoBehaviour
    {
        [SerializeField] private int id;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CheckpointManager.Instance.SetID(id);
            }
        }
    }
}
