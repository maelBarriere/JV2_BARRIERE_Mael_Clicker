using UnityEngine;
using UnityEngine.UI; 
using TMPro;

[CreateAssetMenu(fileName = "ScoreNotificationData", menuName = "ScriptableObjects/ScoreNotificationData", order = 1)]
public class ScoreNotificationData : ScriptableObject
{
    public int scoreThreshold;        
    public Image notificationImage;   
}
