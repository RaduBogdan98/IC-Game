using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.123f;
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.position + offset;
    }
}
