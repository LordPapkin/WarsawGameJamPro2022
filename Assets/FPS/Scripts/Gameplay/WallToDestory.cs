using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class WallToDestory : MonoBehaviour
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private GameObject wholeWall;
        [SerializeField] private GameObject wallPieces;
        private Rigidbody[] rbs;
        private void Awake()
        {
            rbs = wallPieces.GetComponentsInChildren<Rigidbody>();
        }
        public void Hit(Vector3 hitVector)
        {
            boxCollider.enabled = false;
            wholeWall.SetActive(false);
            wallPieces.SetActive(true);

            foreach(var piece in rbs)
            {
                piece.AddForce(hitVector * 2.4f, ForceMode.Impulse );
            }
        }
    }
}