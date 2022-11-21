using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public Vector3 offsetPos;
    public Transform target;
    public bool isClearScore;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.transform.position = target.position + offsetPos;
            other.gameObject.SetActive(true);

            if (isClearScore)
            {
                GameMgr.Instance.ChangeScore(0);
            }
        }
    }
}
