using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPair : MonoBehaviour
{
    private bool search = false;

    private Transform pair;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(other.gameObject);
        }
    }
}
