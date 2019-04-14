using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float followAmount = 0.1f;

    public float xBound;
    public float yBound;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = startPosition + player.position * followAmount;
        if (Mathf.Abs(newPos.x) < xBound && Mathf.Abs(newPos.y) < yBound) {
            transform.position = startPosition + player.position * followAmount;
        }
    }
}
