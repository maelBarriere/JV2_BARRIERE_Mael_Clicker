using UnityEngine;

[CreateAssetMenu(fileName = "AutoHideAndRespawnData", menuName = "ScriptableObjects/AutoHideAndRespawnData", order = 2)]
public class AutoHideAndRespawnData : ScriptableObject
{
    public float hideDelay = 3.0f; 
    public float minimumHideDelay = 0.5f;
    public bool isHidden = false; 
}
