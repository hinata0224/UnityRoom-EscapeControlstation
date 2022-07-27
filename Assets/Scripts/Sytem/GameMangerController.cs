using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameMangerController : MonoBehaviour
{

    [SerializeField] private int necessaryKey = 3;
    private int key = 0;

    [SerializeField] private float endTime = 60;
    private float nowTime = 0;

    [Header("クリアポータルの場所")]
    [SerializeField] private GameObject clearPos;

    [SerializeField] private SceneManagerController scene;
    [SerializeField] private PlayerController player;

    private SceneManagerController scenemanager;

    private void Awake()
    {
        clearPos.SetActive(false);
        scenemanager = GetComponent<SceneManagerController>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        Rezult();
        GetKey();
    }

    //clear後のタイムライン
    void Rezult()
    {
        if(key == necessaryKey)
        {
            clearPos.SetActive(true);
        }
        if (player.GetDead())
        {
            scenemanager.GoLoser();
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
