using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 发光的板子
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Items/Lighting Board")]
[RequireComponent(typeof(ColorChanger))]
public class LightingBoard : Board
{
    private ColorChanger colorChanger;
    [Header("【板子发光器】")]
    [SerializeField]
    [Header("亮度：")]
    [Range(0, 1)]
    private float emissionRate;

    private void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
    }
    protected override void OnBoard(PlayerController player)
    {
        base.OnBoard(player);
        colorChanger.ChangeToColor(targetColor());
    }
    protected override void LeaveBoard(PlayerController player)
    {
        base.LeaveBoard(player);
        colorChanger.ResetColor();
    }
    private Color targetColor()
    {
        return new Color(emissionRate, emissionRate, emissionRate);
    }
}
