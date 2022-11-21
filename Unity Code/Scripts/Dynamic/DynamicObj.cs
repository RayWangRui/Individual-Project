using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DynamicObj : MonoBehaviour
{
    public int dynamicId;
    
    private void Awake()
    {
        DynamicListener.Instance.RegistDynamicObj(dynamicId,this);
    }

    public void OnActive(bool isActive)
    {
        if (gameObject.activeSelf != isActive)
        {
            gameObject.SetActive(isActive);    
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="eventId"></param>
    /// bool值：0 关，1开
    public virtual void OnMessageEvent(int id, int eventId, Transform sender, params object[] paramter)
    {
        //Debug.Log("========== OnMessageEvent id: " + id + " eventId: " + eventId);
        if (id == dynamicId)
        {
            switch (eventId)
            {
                case 0:
                    OnActive(false);
                    break;
                case 1:
                    OnActive(true);
                    break;
            }
        }
    }
}
