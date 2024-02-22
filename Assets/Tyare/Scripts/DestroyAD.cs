using TMPro;
using UnityEngine;

public class DestroyAD : MonoBehaviour
{
    private int RandKey;
    public TMP_Text ADText;

    private void Awake()
    {
        RandKey = Random.Range(0, 5);
    }

    private void Update()
    {
        RandomKey();
    }

    private void RandomKey()
    {
        switch (RandKey)
        {
            case 0:
                ADText.text = "Press Q to close AD";

                if (gameObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;

            case 1:
                ADText.text = "Press E to close AD";

                if (gameObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;

            case 2:
                ADText.text = "Press R to close AD";

                if (gameObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;

            case 3:
                ADText.text = "Press T to close AD";

                if (gameObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;

            case 4:
                ADText.text = "Press Y to close AD";

                if (gameObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.Y))
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;

            case 5:
                ADText.text = "Press U to close AD";

                if (gameObject != null)
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;

            default:
                Debug.Log("Does Nothing");
            break;
        }
    }
}
