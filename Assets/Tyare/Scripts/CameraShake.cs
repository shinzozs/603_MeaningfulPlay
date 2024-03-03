using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    CinemachineImpulseSource Impulse;
    FieldOfView FOV;


    [SerializeField] private float ScreenShakeIntensity20up = 0.0001f;
    [SerializeField] private float ScreenShakeIntensity10to20 = 0.0005f;
    [SerializeField] private float ScreenShakeIntensity10below = 0.001f;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemey;
    [HideInInspector] public float distance;

    private void Start()
    {
        Impulse = GetComponent<CinemachineImpulseSource>();
        FOV = GetComponent<FieldOfView>();
    }

    private void Update()
    {
        if (FOV != null)
        {
            //Debug.Log("Object Is Found");
            if (FOV.canSeePlayer == true)
            {
                if (distance >= 20)
                {
                    Impulse.m_DefaultVelocity = new Vector3(Random.Range(-ScreenShakeIntensity20up, ScreenShakeIntensity20up), Random.Range(-ScreenShakeIntensity20up, ScreenShakeIntensity20up), 0); // Can play around with the values for the screenshake at this ranges
                    Invoke("shake", 0f);
                }
                else if (distance >= 10)
                {
                    Impulse.m_DefaultVelocity = new Vector3(Random.Range(-ScreenShakeIntensity10to20, ScreenShakeIntensity10to20), Random.Range(-ScreenShakeIntensity10to20, ScreenShakeIntensity10to20), 0); // Can play around with the values for the screenshake at this ranges
                    Invoke("shake", 0f);
                }
                else
                {
                    Impulse.m_DefaultVelocity = new Vector3(Random.Range(-ScreenShakeIntensity10below, ScreenShakeIntensity10below), Random.Range(-ScreenShakeIntensity10below, ScreenShakeIntensity10below), 0); // Can play around with the values for the screenshake at this ranges
                    Invoke("shake", 0f);
                }
                distBetween();
                //Debug.Log("Shaking");
            }
        }
        else
        {
            Debug.LogError("Object Is Null");
        }
    }

    void shake()
    {
        Impulse.GenerateImpulse();
    }

    public void distBetween()
    {
        distance = Vector3.Distance(Player.transform.position, Enemey.transform.position);
        Debug.Log(distance);
    }
}
