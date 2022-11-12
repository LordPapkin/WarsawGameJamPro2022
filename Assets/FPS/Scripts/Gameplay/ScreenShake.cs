using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ScreenShake : MonoBehaviour
    {
        private PlayerCharacterController Player;
        [SerializeField] float duration = 2;

        void Start()
        {
            Player = GetComponentInParent<PlayerCharacterController>();
        }

        public void LandShake(float delay)
        {
            StartCoroutine(Shake(0.4f, 0.03f, delay));
        }

        public IEnumerator Shake(float duration, float magnitude, float delay)
        {
            yield return new WaitForSeconds(delay);

            Vector3 orignalPosition = transform.position;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.position = transform.position + new Vector3(x, y, 0);
                elapsed += Time.deltaTime;
                yield return 0;
            }
            transform.position = orignalPosition;
        }
    }

}