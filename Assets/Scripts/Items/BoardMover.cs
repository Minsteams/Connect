using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不能被实例化，提供平滑移动物体方法
/// </summary>
public class BoardMover : MonoBehaviour
{
    public static void Move(Transform board, Vector3 delta, float param, float delaySeconds)
    {
        GameSystem.settings.StartCoroutine(StartMove(board, delta, param, delaySeconds));
    }

    private static IEnumerator StartMove(Transform board, Vector3 delta, float param, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        yield return Moving(board, delta, param);
    }

    private static IEnumerator Moving(Transform board, Vector3 delta, float param)
    {
        if (delta.sqrMagnitude < 0.001f)
        {
            board.Translate(delta);
            yield return 0;
        }
        else
        {
            Vector3 addition = delta * param;
            delta -= addition;
            board.Translate(addition);
            yield return 0;
            yield return Moving(board, delta, param);
        }
    }
}
