using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPos : MonoBehaviour
{
    [SerializeField] private List<Transform> posis = new List<Transform>();

    private void Awake()
    {
        GetTransform();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void GetTransform()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            posis.Add(transform.GetChild(i).gameObject.transform);
        }
    }

    public Transform GetPos()
    {
        Transform pos = posis[Random.Range(0, posis.Count)];
        return pos;
    }
}
