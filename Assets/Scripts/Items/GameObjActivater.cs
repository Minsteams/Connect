using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[AddComponentMenu("Items/GameObject Activater")]
public class GameObjActivater : MonoBehaviour
{
    [Header("与玩家相遇时触发激活或隐藏目标游戏物体")]
    [SerializeField]
    private GameObject target;
    [Header("激活或隐藏：")]
    [SerializeField]
    private bool ifActivate = true;
    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.SetActive(ifActivate);
        }
    }
}
