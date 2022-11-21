using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSender : MonoBehaviour
{
    public int dynamicId;
    public int eventId;

    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SendBoolMsg(bool value)
    {
        DynamicListener.Instance.SendDynamicObjMsg(dynamicId, value?1:0,transform);
    }

    public void SendMsg()
    {
        DynamicListener.Instance.SendDynamicObjMsg(dynamicId, eventId,transform);
    }
}
