using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DynamicListener
{
    private static DynamicListener _instance;

    public static DynamicListener Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DynamicListener();
            }

            return _instance;
        }
    }

    public Dictionary<int, List<DynamicObj>> dataList = new Dictionary<int, List<DynamicObj>>();

    public List<DynamicObj> GetItems(int id)
    {
        if (dataList.ContainsKey(id))
        {
            return dataList[id];
        }

        return null;
    }
    
    public void RegistDynamicObj(int id, DynamicObj dynamicObj)
    {
        if (dataList.ContainsKey(id))
        {
            dataList[id].Add(dynamicObj);
        }
        else
        {
            dataList.Add(id, new List<DynamicObj>{dynamicObj});
        }
    }

    public void SendDynamicObjMsg(int id, UnityAction<int, List<DynamicObj>> OnCall)
    {
        List<DynamicObj> items = GetItems(id);
        if (items != null)
        {
            OnCall.Invoke(id, items);
        }
    }
    
    public void SendDynamicObjMsg(int id, int eventId, Transform sender, params object[] paramter)
    {
        List<DynamicObj> items = GetItems(id);
        if (items != null)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].OnMessageEvent(id, eventId, sender, paramter);
            }
        }
    }
}
