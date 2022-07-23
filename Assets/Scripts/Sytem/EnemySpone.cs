using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpone : MonoBehaviour
{
    [SerializeField] private int setEnemy = 3;

    [SerializeField] private GameObject enemy;

    private List<GameObject> enemys = new List<GameObject>();

    [SerializeField] private SelectPos select;
    void Start()
    {
        SetEnemy();
    }

    void Update()
    {
        
    }

    void SetEnemy()
    {
        if(enemys.Count <= setEnemy)
        {
            for(int i = enemys.Count; i <= setEnemy; i++)
            {

                enemys.Add(gameObject);
            }
            for(int i = 0; i < enemys.Count; i++)
            {
                Transform pos = select.GetPos();
                GameObject obj = Instantiate(enemy, pos.position,pos.rotation);
                obj.GetComponent<AIController>().SetSelectPos(select);
                enemys[i] = obj;
            }
        }
    }
}
