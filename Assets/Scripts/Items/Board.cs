using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 板子父类
/// </summary>
[RequireComponent(typeof(Collider))]
public class Board : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            OnBoard(collision.gameObject.GetComponent<PlayerController>());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            LeaveBoard(collision.gameObject.GetComponent<PlayerController>());
        }
    }
    protected virtual void OnBoard(PlayerController player)
    {

    }
    protected virtual void LeaveBoard(PlayerController player)
    {

    }
}
