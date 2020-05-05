using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.123f;
    public Vector3 offset;
    private Transform cameraTransform;
    private int framesCount = 0;
    public bool shouldCameraTurn = true;
    private static int turnAfterSeconds = 30;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (shouldCameraTurn)
        {
            framesCount++;
            if (framesCount == (turnAfterSeconds * 60))
            {
                Vector3 scale = cameraTransform.localScale;
                cameraTransform.localScale = new Vector3((-1) * scale.x, scale.y, scale.z);
                framesCount = 0;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.position + offset;
    }

    internal static void SetSeconds(int seconds)
    {
        turnAfterSeconds = seconds;
    }
}
