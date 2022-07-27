using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPos : MonoBehaviour
{
    [SerializeField] private SceneManagerController scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene.GoClear();
        }
    }
}
