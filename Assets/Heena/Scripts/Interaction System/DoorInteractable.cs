using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    public bool isInteractable { get; set; }

    CollectKey CollectKey;

    private void Awake()
    {
        CollectKey = FindAnyObjectByType<CollectKey>();
    }

    public void Interact()
    {
        if (CollectKey.keyCollected == 1)
        {
            Debug.Log("Door Interacted");
            gameObject.SetActive(false);
        }
    }
}
