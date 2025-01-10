using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    private List<AutoHideAndRespawn> hiddenObjects = new List<AutoHideAndRespawn>();
    public ScoreManager scoreManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddToHiddenList(AutoHideAndRespawn obj)
    {
        if (!hiddenObjects.Contains(obj))
        {
            hiddenObjects.Add(obj);
            Debug.Log("Ajout de l'objet caché : " + obj.name);
        }
    }

    public void RespawnFirstHiddenObject()
    {
        if (hiddenObjects.Count > 0)
        {
            AutoHideAndRespawn firstHiddenObject = hiddenObjects[0];
            firstHiddenObject.RespawnObject();
            hiddenObjects.RemoveAt(0);
        }
        else
        {
            Debug.LogWarning("Aucun objet caché à faire réapparaître !");
        }
    }

    public void RespawnFirstHiddenObjectManual()
    {
        if (hiddenObjects.Count > 0)
        {
            AutoHideAndRespawn firstHiddenObject = hiddenObjects[0];
            Debug.Log("Réapparition manuelle de l'objet : " + firstHiddenObject.name);
            firstHiddenObject.RespawnObject();
            hiddenObjects.RemoveAt(0);
        }
        else
        {
            Debug.LogWarning("Aucun objet caché à faire réapparaître !");
        }
    }
}
