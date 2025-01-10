using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewScoreImageRange", menuName = "ScriptableObjects/ScoreImageRange", order = 1)]
public class ScoreImageRangeSO : ScriptableObject
{
    public int minScore; 
    public int maxScore; 
    public Image notificationImage; 
    public float displayDuration = 1f; 
    [HideInInspector] public bool imageDisplayed = false;
}

