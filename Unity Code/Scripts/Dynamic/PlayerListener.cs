using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : DynamicObj
{
    // bg music
    private AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    // arrow
    public Transform arrow1;
    public Transform arrow2;
    public Transform targetArrow1;
    public Transform targetArrow2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DynamicListener.Instance.RegistDynamicObj(0,this);
        DynamicListener.Instance.RegistDynamicObj(99,this);
    }

    private void Update()
    {
        UpdateArrow(arrow1, targetArrow1);
        UpdateArrow(arrow2, targetArrow2);
    }

    private void UpdateArrow(Transform arrow, Transform target)
    {
        if (target == null)
        {
            if(arrow.gameObject.activeSelf)
                arrow.gameObject.SetActive(false);
        }
        else
        {
            if(!arrow.gameObject.activeSelf)
                arrow.gameObject.SetActive(true);
            arrow.LookAt(target.position + Vector3.up*2);
        }
    }

    public override void OnMessageEvent(int id, int eventId, Transform sender, params object[] paramter)
    {
        switch (id)
        {
            case 0:
                // city
                CityConfig cityConfig = sender.GetComponent<CityConfig>();
                targetArrow1 = cityConfig.arrow1;
                targetArrow2 = cityConfig.arrow2;
                _audioSource.clip = audioClips[cityConfig.musicEventId];
                _audioSource.Play();
                break;
            case 99:
                targetArrow1 = null;
                targetArrow2 = null;
                break;
        }
    }
}
