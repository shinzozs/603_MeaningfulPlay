using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour,IInteractable
{
    public bool isInteractable { get; set; }
    public void Interact()
    {
        Debug.Log("Key Collected");
        gameObject.SetActive(false);
    }
}
