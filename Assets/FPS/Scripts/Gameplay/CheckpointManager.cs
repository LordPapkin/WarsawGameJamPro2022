using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class CheckpointManager : MonoBehaviour
    {
        public static CheckpointManager Instance { get; private set; }
        [SerializeField] private int currentId;
        [SerializeField] private GameObject[] checkpoints;
        private GameObject player;

        public void SetID(int value)
        {
            currentId = value;
        }

        public Vector3 GetSpawnPoint()
        {
            return checkpoints[currentId].transform.position;
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}