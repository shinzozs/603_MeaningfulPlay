using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFlash : MonoBehaviour
{
    [SerializeField] GameObject Cameraflash;

    FieldOfView FOV;
    CameraShake Shake;
    private void Start()
    {
        FOV = GetComponent<FieldOfView>();
        Shake = GetComponent<CameraShake>();
    }

    private void Update()
    {
        if (FOV != null)
        {
            //Debug.Log("Object Is Found");
            if (FOV.canSeePlayer == true)
            {
                if (Shake.distance <= 15)
                {
                    StartCoroutine(buffer());
                }
                else
                {
                    StopCoroutine(buffer());
                }
                //Debug.Log("CameraFlash");
            }
            //Cameraflash.SetActive(false);
        }
        else
        {
            Debug.LogError("Object Is Null");
        }
    }

    void Flash(bool active)
    {
        if (Cameraflash != null)
        {
            Cameraflash.SetActive(active);
        }
    }

    IEnumerator startFlash()
    {
        Flash(true);
        yield return new WaitForSeconds(1f);
        Flash(false);
        StopCoroutine(startFlash());
        yield return new WaitForSeconds(10f);
    }

    IEnumerator buffer()
    {
        yield return StartCoroutine("startFlash");
    }
}
