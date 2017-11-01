using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 随鼠标旋转的组件
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("MyAssets/MouseRotater")]
public class MouseRotater : MonoBehaviour {
    [Header("【随鼠标旋转的组件】")]
    [Header("灵敏度")]
    [SerializeField]
    private float Xsensitivity = 1;
    [SerializeField]
    private float Ysensitivity = 1;
    [Header("隐藏光标")]
    [SerializeField]
    private bool hideMouseOnPlay;

    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        transform.Rotate(- y * Ysensitivity, 0, 0, Space.Self);
        transform.Rotate(0, x * Xsensitivity, 0, Space.World);
    }

    private void Start()
    {
        Cursor.visible = !hideMouseOnPlay;
    }
}
