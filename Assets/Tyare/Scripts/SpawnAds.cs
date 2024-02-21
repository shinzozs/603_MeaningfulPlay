using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAds : MonoBehaviour
{
    public GameObject ADWindow;
    public Transform ADCanvas;
    //public Transform Spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(ADWindow, ADCanvas);
            Debug.Log("Collision");
        }
    }
}
