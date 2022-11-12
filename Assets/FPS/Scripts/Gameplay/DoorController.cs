using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [Header("Open")]
    [SerializeField] float openHeight = -10;
    [SerializeField] float openDuration = 1;
    [SerializeField] Ease openEase;

    [Header("Close")]
    [SerializeField] float closeDuration = -10;
    [SerializeField] Ease closeEase;

    float startHeight;

    private void Start()
    {
        startHeight = transform.position.y;
    }

    public void Open()
    {
        transform.DOLocalMoveY(openHeight, openDuration)
            .SetEase(openEase);
    }

    public void Close()
    {
        transform.DOLocalMoveY(startHeight, closeDuration)
            .SetEase(closeEase);
    }
}
