using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Params")]
    public float playerStamina = 100f;
    public float maxStamina = 100f;

    [Header("Stamina Regen Params")]
    [Range(0, 50)] public float staminaDrain;
    [Range(0, 50)] public float staminaRegen;

    [Header("Stamina Speed Params")]
    public Image staminaProgressUI = null;
    public CanvasGroup sliderCanvassGroup = null;

    PlayerMovement PlayerMovement;


    private void Start()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        sliderCanvassGroup.alpha = 0;
    }
}
