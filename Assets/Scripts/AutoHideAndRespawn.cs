using UnityEngine;
using System.Collections;

public class AutoHideAndRespawn : MonoBehaviour
{
    public float hideDelay = 3.0f;
    public float minimumHideDelay = 0.5f;
    public GameObject child;

    private bool isHidden = false;

    private void Start()
    {
        StartCoroutine(HideObjectAfterDelay());
    }

    private IEnumerator HideObjectAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        HideObject();
    }

    private void HideObject()
    {
        if (!isHidden)
        {
            isHidden = true;

            if (child != null)
            {
                child.SetActive(false);
            }

            if (Manager.Instance != null)
            {
                Manager.Instance.AddToHiddenList(this);
            }

            DecreaseHideDelay();
        }
    }

    private void DecreaseHideDelay()
    {
        hideDelay = Mathf.Max(hideDelay - 0.1f, minimumHideDelay);
    }

    public void RespawnObject()
    {
        if (isHidden)
        {
            if (child != null)
            {
                child.SetActive(true);
            }

            isHidden = false;

            if (Manager.Instance != null && Manager.Instance.scoreManager != null)
            {
                Manager.Instance.scoreManager.AddScore();
            }

            StartCoroutine(HideObjectAfterDelay());
        }
    }

    public bool IsHidden()
    {
        return isHidden; // Retourne si l'objet est caché ou non
    }
}



