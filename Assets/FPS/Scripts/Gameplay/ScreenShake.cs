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
            StartCoroutine(Shake(2, 0.2f));
        }

        public IEnumerator Shake(float duration, float magnitude)
        {
            yield return new WaitForSeconds(3);

            Vector3 orignalPosition = transform.position;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.position = new Vector3(x, y, -10f);
                elapsed += Time.deltaTime;
                yield return 0;
            }
            transform.position = orignalPosition;
        }
    }

}