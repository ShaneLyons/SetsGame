using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustleGrass : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("rustle");
        }
    }
}
