using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject happyBSOD;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(8f);
        happyBSOD.SetActive(false);
        yield return new WaitForSeconds(2f);
        Quit();
    }

    private void Quit()
    {        
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
