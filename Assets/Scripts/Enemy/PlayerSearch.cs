using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private AIController ai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ai.InPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ai.OutPlaer();
        }
    }
}
