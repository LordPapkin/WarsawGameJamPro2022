using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.FPS.Gameplay;

namespace Unity.FPS.AI
{
    public class SpawnAnimation : MonoBehaviour
    {
        [SerializeField] float fallDuration;
        [SerializeField] float finishedAnimationHeight;
        [SerializeField] Ease ease;
        [SerializeField] float shakeStrength = 25;
        [SerializeField] bool shake = true;

        [HideInInspector] public bool finished = false;
        ScreenShake screenShake;

        private void Start()
        {
            screenShake = FindObjectOfType<ScreenShake>();
        }

        public void StartAnimation()
        {
            transform.DOLocalMoveY(finishedAnimationHeight, fallDuration)
                .SetEase(ease)
                .OnComplete(() => { finished = true; });

            if (shake)
                StartCoroutine(Shake(fallDuration - (fallDuration * 0.65f)));
        }

        IEnumerator Shake(float delay)
        {
            yield return new WaitForSeconds(delay);

            CinemamachineShake.Instance.ShakeCamera(shakeStrength, 0.3f);
        }
    } 
}
