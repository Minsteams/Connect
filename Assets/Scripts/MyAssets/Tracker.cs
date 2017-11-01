using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平滑追踪transform
/// </summary>
[AddComponentMenu("MyAssets/Tracker")]
[DisallowMultipleComponent]
public class Tracker : MonoBehaviour {
    [Header("【Transform追踪器】")]

    public Transform target;
    [Header("平滑度")]
    [Range(0.7f,0.98f)]
    public float smoothness = 0.95f;
    [Header("是否追踪角度")]
    public bool ifRotate = false;
    [Header("开关")]
    public bool isTracking = true;

    private void FixedUpdate()
    {
        if (isTracking)
        {
            transform.position += ((1 - smoothness) * (target.position - transform.position));
            if (ifRotate)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, 1 - smoothness);
            }
        }
    }
}
