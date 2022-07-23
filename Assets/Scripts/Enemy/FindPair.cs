using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPair : MonoBehaviour
{

    private List<GameObject> pair = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            pair.Add(other.gameObject);
        }
    }
}
