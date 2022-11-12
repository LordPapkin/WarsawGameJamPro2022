using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMedkit : MonoBehaviour
{
    [SerializeField] private GameObject[] medkits;
    [SerializeField] private float timeToSpawn;

    private GameObject currentMedkit;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            SpawnHealthPickUp();
        }       
    }

    private void SpawnHealthPickUp()
    {        
        if(currentMedkit == null)
        {
            currentMedkit = Instantiate(medkits[UnityEngine.Random.Range(0, medkits.Length)], transform.position, Quaternion.identity);
        }
    }
}
