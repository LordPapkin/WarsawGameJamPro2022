using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Unity.FPS.AI
{
    public class SpawnAnimation : MonoBehaviour
    {
        [SerializeField] float fallDuration;
        [SerializeField] float finishedAnimationHeight;
        [SerializeField] Ease ease;

        [HideInInspector] public bool finished = false;

        public void StartAnimation()
        {
            transform.DOLocalMoveY(finishedAnimationHeight, fallDuration)
                .SetEase(ease)
                .OnComplete(() => { finished = true; });
        }
    } 
}
