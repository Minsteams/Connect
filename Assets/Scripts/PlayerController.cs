using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制人物移动的类
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("【人物组件】")]
    [Header("速度")]
    [SerializeField]
    private float speed;
    [Header("重力加速度")]
    [SerializeField]
    private float g;
    private float ySpeed;
    [SerializeField] private float jumpSpeed;
    private bool isGround = false;
    [Header("转弯平滑度")]
    [SerializeField]
    [Range(0.05f, 0.95f)]
    private float smoothness;
    private Animator animator;
    [HideInInspector]
    public Vector3 dir;
    public BuffDelegate Buff;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        KeyBoardInput();
    }

    /// <summary>
    /// 当前接触地板数量
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" && collision.contacts[0].thisCollider.tag == "Player")
        {
            collision.collider.tag = "TouchedGround";
            isGround = true;
            animator.SetBool("isGround", true);
            GetComponent<ParticleSystem>().Play();
            ySpeed = 0;
            //print(1);
        }
        else if(collision.collider.tag == "TouchedGround")
        {
            isCollisionRouse = true;
        }
    }
    private bool isCollisionRouse;//干扰
    private void OnCollisionExit(Collision collision)
    {
        if (isCollisionRouse)
        {
            //被不是脚上的碰撞箱干扰！
            isCollisionRouse = false;
        }
        else if (collision.collider.tag == "TouchedGround")
        {
            collision.collider.tag = "Ground";
            //print(0);
            isGround = false;
            animator.SetBool("isGround", false);
            GetComponent<ParticleSystem>().Stop();
        }

    }

    private void KeyBoardInput()
    {
        if (GameSystem.InputKeys.Jump()) Jump();
        float h = GameSystem.InputKeys.Horizontal();
        float v = GameSystem.InputKeys.Vertical();
        Move(h, v);
    }

    private void Jump()
    {
        ySpeed = jumpSpeed;
    }
    private void Move(float h, float v)
    {
        if (!isGround && ySpeed > -8)
        {
            ySpeed -= g * Time.deltaTime;
        }
        Vector3 dirXY = new Vector3(h * speed, 0, v * speed);
        animator.SetFloat("v", dirXY.magnitude);
        dir = dirXY + Vector3.up * ySpeed;

        //特殊状态
        if (Buff != null) Buff(this);

        if (dirXY.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirXY, Vector3.up), 1 - smoothness);
        }
        GetComponent<Rigidbody>().velocity = dir;
    }
}
