using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class LookAtPlayer : MonoBehaviour
{
    PlayerCharacterController characterController;

    void Start()
    {
        characterController = FindObjectOfType<PlayerCharacterController>();
    }

    void Update()
    {
        transform.LookAt(characterController.transform.position + Vector3.up);
    }
}
