using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityConfig : DynamicObj
{
    public int receiveId;
    public int sendId;
    public int musicEventId;
    public Transform arrow1;

    public Transform arrow2;
    
    // Start is called before the first frame update
    void Start()
    {
        DynamicListener.Instance.RegistDynamicObj(receiveId,this);
    }

    public override void OnMessageEvent(int id, int eventId, Transform sender, params object[] paramter)
    {
        DynamicListener.Instance.SendDynamicObjMsg(0, 0, transform);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
