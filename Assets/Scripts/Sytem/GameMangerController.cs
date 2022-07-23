using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameMangerController : MonoBehaviour
{

    [SerializeField] private int necessaryKey = 3;
    private int key = 0;

    private static int allyp;
    private static int enemyp;

    [SerializeField] private float endTime = 60;
    private float nowTime = 0;

    [Header("クリアポータルの場所")]
    [SerializeField] private GameObject clearPos;

    [SerializeField] private PlayableDirector endTimeline;

    [SerializeField] private SceneManagerController scene;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        endTimeline.Pause();
        clearPos.SetActive(false);
    }
    void Start()
    {
        
    }

    void Update()
    {
        LimitTime();
        GetKey();
    }

    //clear後のタイムライン
    void LimitTime()
    {
        //nowTime += Time.deltaTime;
        //if(endTime <= nowTime)
        //{
        //    player.TimeUp();
        //    StaticPoint();
        //    endTimeline.Play();
        //}
        if(key == necessaryKey)
        {
            clearPos.SetActive(true);
        }
    }
    //鍵のゲット
    public void GetKey()
    {
        key = player.GetKey();
    }
    
    //UI用
    public int ReturnKey()
    {
        return key;
    }
    public int ReturnMaxKey()
    {
        return necessaryKey;
    }
}
