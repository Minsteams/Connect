using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动板子
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class MovingBoard : Board {
    protected Vector3 v;
    private void Update()
    {
        Move(transform);
        VolecityFlush();
    }
    private void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
    }
    protected virtual void VolecityFlush()
    {

    }
    protected override void OnBoard(PlayerController player)
    {
        base.OnBoard(player);
        player.Buff += MovePlayer;
    }
    protected override void LeaveBoard(PlayerController player)
    {
        base.LeaveBoard(player);
        player.Buff -= MovePlayer;
    }
    private void MovePlayer(PlayerController player)
    {
        player.dir += v;
    }
    private void Move(Transform target)
    {
        GetComponent<Rigidbody>().velocity = v;
    }
}
