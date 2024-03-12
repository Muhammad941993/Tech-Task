using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] List<Transform> UIWindows;

    private void Start()
    {
        DisableAllUI();
    }
    public void DisableAllUI()
    {
        foreach (var item in UIWindows)
        {
            item.gameObject.SetActive(false);
        }
    }
}
