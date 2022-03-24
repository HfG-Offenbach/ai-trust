using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startLightSync : MonoBehaviour
{
    [SerializeField] private bool SyncLight = true;

    [Tooltip("Time in seconds the screen will flash for sync")] public float syncFlashDuration;

    public GameObject lightPanel;

    private IEnumerator coroutine;

    public void OpenLightPanel()
    {
        if (lightPanel != null)
        {
            bool isActive = lightPanel.activeSelf;

            lightPanel.SetActive(!isActive);
        }
    }

    void Start()
    {
        coroutine = SwitchColor(0.5f);
        StartCoroutine(coroutine);
    }

    private IEnumerator SwitchColor(float waitTime)
    {
        while (SyncLight == true)
        {
            for (int i = 0; i < 5; i++)
            {
                lightPanel.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                yield return syncFlashDuration;
                lightPanel.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                yield return syncFlashDuration;
            }
        }
    }
}
