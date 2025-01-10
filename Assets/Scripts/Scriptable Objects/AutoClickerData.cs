using UnityEngine;

[CreateAssetMenu(fileName = "AutoClickerData", menuName = "ScriptableObjects/AutoClickerData", order = 3)]
public class AutoClickerData : ScriptableObject
{
    public bool isAutoClicking = false; 
    public float clickInterval = 1.0f; 
}
