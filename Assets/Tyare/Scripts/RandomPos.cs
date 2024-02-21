using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public RectTransform rectTransform;
    float XAxis, YAxis;

    void Awake()
    {
        XAxis = Random.Range(-300, 300);
        YAxis = Random.Range(-160, 160);
        rectTransform.anchoredPosition = new Vector2(XAxis, YAxis);
    }
}
