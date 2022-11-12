using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] DoorController doorController;
    [SerializeField] bool openTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
                doorController.Open();
            else
                doorController.Close();
        }
    }
}
