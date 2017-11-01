using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 平滑改变颜色
/// </summary>
[AddComponentMenu("MyAssets/Color Changer")]
public class ColorChanger : MonoBehaviour {
    private Material material;
    private Color origColor;
    [SerializeField] private string colorName;

    [Range(0.7f, 0.96f)]
    [SerializeField]
    [Header("平滑度（默认0.897）")]
    private float smoothness = 0.897f;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        origColor = material.GetColor(colorName);
    }

    private void Reset()
    {
        smoothness = 0.897f;
        colorName = "_EmissionColor";
    }

    /// <summary>
    /// 切换到指定颜色
    /// </summary>
    /// <param name="target"></param>
    public void ChangeToColor(Color target)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeTo(target));
    }

    public void ResetColor()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeTo(origColor));
    }

    private IEnumerator ChangeTo(Color target)
    {
        Color c = material.GetColor(colorName);
        float delta = target.grayscale - c.grayscale;
        if (delta < 0.01f && delta > -0.01f)
        {
            material.SetColor(colorName, target);
            yield return 0;
        }
        else
        {
            material.SetColor(colorName, Color.Lerp(c, target, 1 - smoothness));
            yield return 0;
            yield return ChangeTo(target);
        }
    }
}
