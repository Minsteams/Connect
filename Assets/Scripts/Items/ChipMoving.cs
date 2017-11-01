using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Items/Chip Moving")]
public class ChipMoving : MovingBoard {

    [Header("【平台移动组件】")]
    [Header("速度")]
    [SerializeField]
    private float speed;
    [Header("高度")]
    [SerializeField]
    private float height;
    private float theta;
    [SerializeField]
    private Vector3 rot;

    private void Start()
    {
        theta = 0;
    }
    protected override void VolecityFlush()
    {
        base.VolecityFlush();
        theta += speed;
        v = Vector3.up * height * Mathf.Cos(theta / 360);
        transform.Rotate(rot);
    }
}
