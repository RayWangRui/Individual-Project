using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosSender : MonoBehaviour
{
    [Header("100 未来世界，101 海边，102 沙漠，103 普通城市 99 桥 80 现实世界")]public int sendId;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DynamicListener.Instance.SendDynamicObjMsg(sendId, 0,transform);
        }
    }
}
