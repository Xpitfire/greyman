using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMove : MonoBehaviour
{
    [SerializeField]
    Transform start;

    [SerializeField]
    Transform end;

    [SerializeField]
    Transform platform;

    [SerializeField]
    float speed;

    private Vector3 direction;
    private Transform destination;

    void Start()
    {
        SetDestination(start);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(start.position, platform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(end.position, platform.localScale);
    }

    void FixedUpdate()
    {
        platform.gameObject.GetComponent<Rigidbody>().MovePosition(platform.position + direction * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(platform.position, destination.position) < speed*Time.fixedDeltaTime)
        {
            SetDestination(destination == start ? end : start);
        }
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
    
}
