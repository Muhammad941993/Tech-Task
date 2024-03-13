using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] List<Transform> uIWindows;

    private void Start()
    {
        DisableAllUI();
    }
    public void DisableAllUI()
    {
        foreach (var item in uIWindows)
        {
            item.gameObject.SetActive(false);
        }
    }
}
