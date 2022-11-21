using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicActive : MonoBehaviour
{
    public GameObject[] showList;

    public GameObject[] hideList;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetActive(showList, true);
            SetActive(hideList, false);
        }
    }

    private void SetActive(GameObject[] list , bool isActive)
    {
        for (int i = 0; i < list.Length; i++)
        {
            GameObject go = list[i];
            if (go == null) continue;
            go.SetActive(isActive);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
