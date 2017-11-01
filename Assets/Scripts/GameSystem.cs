using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public static GameSystem settings;
    private void Awake()
    {
        settings = this;
    }
    public static class InputKeys
    {
        public static bool Jump()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        public static float Horizontal()
        {
            return Input.GetAxis("Horizontal");
        }
        public static float Vertical()
        {
            return Input.GetAxis("Vertical");
        }
        public static bool Interact()
        {
            return Input.GetKeyDown(KeyCode.F);
        }
    }
}
public delegate void BuffDelegate(PlayerController player);
