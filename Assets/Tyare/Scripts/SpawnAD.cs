using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnAD : MonoBehaviour
{
    public GameObject ADWindow;
    public Transform ADCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(ADWindow, ADCanvas);
            Debug.Log("Collision");
        }
    }
}