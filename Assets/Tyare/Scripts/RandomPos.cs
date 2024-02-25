using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public RectTransform RectTransform;
    float XAxis, YAxis;

    void Awake()
    {
        RandomXY();
    }

    private void RandomXY()
    {
        XAxis = Random.Range(-300, 300);
        YAxis = Random.Range(-160, 160);
        RectTransform.anchoredPosition = new Vector2(XAxis, YAxis);
    }
}
