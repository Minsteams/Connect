using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 传送平台
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Items/Portal Board")]
public class PortalBoard : Board {
    [Header("【传送平台】")]
    [SerializeField]
    private Transform targetPos;
    protected override void OnBoard(PlayerController player)
    {
        base.OnBoard(player);
        player.Buff += Transport;
    }
    protected override void LeaveBoard(PlayerController player)
    {
        base.LeaveBoard(player);
        player.Buff -= Transport;
    }
    private void Transport(PlayerController player)
    {
        if (GameSystem.InputKeys.Interact())
        {
            player.transform.position = targetPos.position;
        }
    }
}
