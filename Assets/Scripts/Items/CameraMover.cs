using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动相机，与触发器配合
/// </summary>
[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
[AddComponentMenu("Items/Camera Mover")]
public class CameraMover : MonoBehaviour
{
    [Header("【触发器移动相机组件】")]
    [SerializeField]
    private Camera cam;
    [Header("平滑度")]
    [SerializeField]
    [Range(0.7f, 0.98f)]
    private float smoothness = 0.95f;
    [Header("是否跟随")]
    [SerializeField]
    private bool ifFollow = true;

    private Vector3 deltaPos;
    private Quaternion rotation;
    private float fieldOfView;
    private Tracker tracker;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
        deltaPos = ifFollow ? cam.transform.position - transform.position : cam.transform.position;
        rotation = cam.transform.rotation;
        fieldOfView = cam.fieldOfView;
        tracker = Camera.main.GetComponentInParent<Tracker>();
        Destroy(cam);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tracker.StopAllCoroutines();
            Camera.main.transform.parent = null;
            tracker.transform.position = other.transform.position;
            tracker.isTracking = ifFollow;
            Camera.main.transform.parent = tracker.transform;
            print("start moving camera...");
            tracker.StartCoroutine(SetCamera());
        }
    }

    private IEnumerator SetCamera()
    {
        Vector3 targetPos = ifFollow ? tracker.transform.position + deltaPos : deltaPos;
        float delta = (targetPos - Camera.main.transform.position).magnitude;
        if (InRange(delta))
        {
            Camera.main.transform.position = targetPos;
            Camera.main.transform.rotation = rotation;
            Camera.main.fieldOfView = fieldOfView;
            print("success moving camera!");
            yield return 0;
        }
        else
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, 1 - smoothness);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, rotation, 1 - smoothness);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fieldOfView, 1 - smoothness);
            yield return 0;
            yield return SetCamera();
        }
    }

    private bool InRange(float a)
    {
        return a < 0.01f && a > -0.01f;
    }
}
