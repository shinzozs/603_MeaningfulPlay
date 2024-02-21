using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class DestroyAD : MonoBehaviour
{
    public void Destroy() 
    {
        if (gameObject != null) 
        {
            Destroy(this.gameObject);
        }
    }
}
