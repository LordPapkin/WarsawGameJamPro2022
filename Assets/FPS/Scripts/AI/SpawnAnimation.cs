using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class SpawnAnimation : MonoBehaviour
    {
        public bool animating = true;

        [SerializeField] float fallSpeed;


        private void Update()
        {
            if (animating)
            {
                var newPos = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
                transform.position = newPos;

                RaycastHit hit;
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
                {
                    animating = false;
                }
            }
        }
    } 
}
