using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Items/Circle Moving Board")]
public class CircleMovingBoard : MovingBoard
{
    [Header("【平台移动组件】")]
    [Header("轴心点")]
    [SerializeField]
    private Transform centrePoint;
    [SerializeField]
    private float speed;
    [Header("方向反转")]
    [SerializeField]
    private bool invert;
    protected override void VolecityFlush()
    {
        base.VolecityFlush();
        v = (invert ? -1 : 1) * Vector3.Cross(transform.position - centrePoint.position, centrePoint.up)/10 * speed;
    }
}
