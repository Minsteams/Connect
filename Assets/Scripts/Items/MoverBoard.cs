using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Items/Mover Board")]
public class MoverBoard : Board {
    [Header("【踩上去可以控制其他平台移动的组件】")]
    [Header("移动目标")]
    public Transform target;
    [Header("移动距离")]
    public Vector3 delta;
    [Header("平滑度")]
    [Range(0.9f, 0.999f)]
    public float smoothness = 0.9915f;
    [Header("延迟")]
    public float delaySeconds;

    private void Reset()
    {
        smoothness = 0.9915f;
        delaySeconds = 0;
        delta = Vector3.up;
    }
    protected override void OnBoard(PlayerController player)
    {
        base.OnBoard(player);
        BoardMover.Move(target, delta, 1 - smoothness, delaySeconds);
        Destroy(this);
    }
}
