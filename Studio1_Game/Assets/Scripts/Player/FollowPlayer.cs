using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;

    Vector3 camOffset;

    float slerpMultiplier = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Player.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, slerpMultiplier);
    }
}
