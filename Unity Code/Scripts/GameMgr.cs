using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public float distance;
    public Transform[] root;

    public List<npc> npcList = new List<npc>();

    public static GameMgr Instance;

    public int score;

    public Renderer playerRender;
    
    public const int defaultScore = 200;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = defaultScore;
        for (int i = 0; i < root.Length; i++)
        {
            npc[] list = root[i].GetComponentsInChildren<npc>();
            npcList.AddRange(list);
        }
    }

    public bool HasNpc()
    {
        npc npc;
        for (int i = 0; i < npcList.Count; i++)
        {
            npc = npcList[i];
            float dis = Util.GetHorizontalDistance(transform.position, npc.transform.position);
            if (dis < distance)
            {
                return true;
            }
        }

        return false;
    }

    public void ChangeScore(int score)
    {
        this.score += score;
        
        Color color;
        if (this.score == defaultScore)
        {
            color = Color.gray;
        }
        else if (this.score > defaultScore)
        {
            if (this.score > 300)
            {
                color = Color.Lerp(Color.white, Color.green, (this.score - 300) / 100f);    
            }
            else
            {
                color = Color.Lerp(Color.gray, Color.white, (this.score - defaultScore) / 100f);
            }
        }
        else
        {
            if (this.score > 100)
            {
                color = Color.Lerp(Color.red,Color.gray, (this.score-100) / 100f);    
            }
            else
            {
                color = Color.Lerp(Color.black,Color.red, (this.score) / 100f);
            }
            
        }
        // Debug.Log("=============color: " + color);
        for (int i = 0; i < playerRender.materials.Length; i++)
        {
            
            playerRender.materials[i].color = color;
        }
    }
}