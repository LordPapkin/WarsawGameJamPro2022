using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab");
            if (inGameMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                inGameMenu.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                inGameMenu.SetActive(true);
            }            
        }
    }
}
