using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustleGrass : MonoBehaviour
{
    private Animator anim;

    public List<Sprite> grass;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();

        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = grass[Random.Range(0, grass.Count)];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("rustle");
        }
    }
}
