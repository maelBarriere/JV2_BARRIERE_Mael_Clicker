using UnityEngine;
using TMPro;

public class AutoClicker : MonoBehaviour
{
    public float clickInterval = 1.0f; 
    private float nextClickTime = 0f; 
    private bool isAutoClicking = false; 
    private bool isDoubleSpeedActive = false; 

    public TMP_Text buttonText; 

    void Update()
    {
        if (isAutoClicking && Time.time >= nextClickTime)
        {
            AutoRespawnObject();
            nextClickTime = Time.time + clickInterval;
        }
    }

    public void ToggleAutoClicker()
    {
        isAutoClicking = !isAutoClicking; 

        if (buttonText != null)
        {
            buttonText.text = isAutoClicking ? "Auto-Click On" : "Auto-Click Off";
        }
    }

    private void AutoRespawnObject()
    {
        if (Manager.Instance != null)
        {
            Manager.Instance.RespawnFirstHiddenObject();
        }
        else
        {
            Debug.LogWarning("Manager.Instance est null !");
        }
    }

    public void ToggleDoubleSpeed()
    {
        if (isDoubleSpeedActive)
        {
            clickInterval = 1.0f; 
            isDoubleSpeedActive = false;
        }
        else
        {
            clickInterval = Mathf.Max(clickInterval / 2, 0.1f);
            isDoubleSpeedActive = true;
        }
    }
}

