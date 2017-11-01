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
    [Header("开关")]
    public bool isTracking = true;
    [Header("平滑度")]
    [Range(0.7f,0.98f)]
    public float smoothness = 0.95f;
    [Header("是否追踪位置")]
    public bool ifMove = true;
    [Header("是否平滑")]
    [ConditionalHide("ifMove",false)]
    public bool ifMoveSmoothly = true;
    [Header("是否追踪角度")]
    public bool ifRotate = false;
    [Header("是否平滑")]
    [ConditionalHide("ifRotate", false)]
    public bool ifRotateSmoothly = true;


    private void FixedUpdate()
    {
        if (isTracking)
        {
            if (ifMove)
            {
                if (ifMoveSmoothly)
                {
                    transform.position += ((1 - smoothness) * (target.position - transform.position));
                }
                else
                {
                    transform.position = target.position;
                }
            }
            if (ifRotate)
            {
                if (ifRotateSmoothly)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, 1 - smoothness);
                }
                else
                {
                    transform.rotation = target.rotation;
                }
            }
        }
    }
}
