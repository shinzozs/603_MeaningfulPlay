using TMPro;
using UnityEngine;

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
        if (gameObject != null)
        {
            if (Input.GetKeyDown(Randkey))
            {
                Destroy(gameObject);
            }
        }
    }

    void CreateText(KeyCode key)
    {
        Keystring = System.Enum.GetName(typeof(KeyCode), key);
        ADText.text = "Press "+ Keystring +" to close AD";
    }
}
