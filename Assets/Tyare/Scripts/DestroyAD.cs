using System;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class DestroyAD : MonoBehaviour
{
    private string Chars = "BCEFGHIJKLMNOPQRTUVXYZ";
    private string Randchar;
    private string Keystring;
    private KeyCode Randkey;

    public TMP_Text ADText;

    private void Awake()
    {
        for(int i = 0; i < 1; i++)
        {
            Randchar += Chars[Random.Range(0, Chars.Length)];
        }
        //Debug.Log(Randchar);
        Randkey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Randchar);

        CreateText(Randkey);
    }

    private void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            DisableKey(Randkey);
        }
        else
        {
            if (gameObject != null)
            {
                if (Input.GetKeyDown(Randkey))
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void CreateText(KeyCode key)
    {
        Keystring = System.Enum.GetName(typeof(KeyCode), key);
        ADText.text = "Press "+ Keystring +" to close AD";
    }

    void DisableKey(KeyCode key)
    {
        // You may now catch null reference here.
        try
        {
            if (Event.current.keyCode == key && (Event.current.type == EventType.KeyUp || Event.current.type == EventType.KeyDown))
            {
                Event.current.Use();
            }
        }
        catch (NullReferenceException)
        {
            Debug.LogError("Ignore for now");
        }
    }
}
