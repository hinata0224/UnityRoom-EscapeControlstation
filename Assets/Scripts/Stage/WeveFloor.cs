using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FloorType
{
    Up,
    Down
}

public class WeveFloor : MonoBehaviour
{
    [SerializeField] private FloorType type;

    private string up = "UpFloor";
    private string down = "DownFloor";


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            if(FloorType.Up == type)
            {
                animator.SetBool(up,true);
            }
            else
            {
                animator.SetBool(down, true);
            }
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (FloorType.Up == type)
            {
                animator.SetBool(up, false);
            }
            else
            {
                animator.SetBool(down, false);
            }
            collision.gameObject.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            if (FloorType.Up == type)
            {
                animator.SetBool(up, true);
            }
            else
            {
                animator.SetBool(down, true);
            }
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            if (FloorType.Up == type)
            {
                animator.SetBool(up, false);
            }
            else
            {
                animator.SetBool(down, false);
            }
            other.gameObject.transform.parent = null;
        }
    }
}
