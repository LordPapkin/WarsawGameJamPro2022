using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject happyBSOD;
    private void Start()
    {
        StartCoroutine(StartEnd());
    }

    private IEnumerator StartEnd()
    {
        yield return new WaitForSecondsRealtime(8f);
        happyBSOD.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        Quit();
    }

    private void Quit()
    { 
        Application.Quit();
    }
}
