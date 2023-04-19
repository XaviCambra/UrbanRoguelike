using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Inputs")]
    public KeyCode m_ForwardKey = KeyCode.W;
    public KeyCode m_BackKey = KeyCode.S;
    public KeyCode m_LeftKey = KeyCode.A;
    public KeyCode m_RightKey = KeyCode.D;
    //Crouch
    public KeyCode m_LeftShiftKey = KeyCode.LeftShift;
    //Item
    public KeyCode m_UseItemKey = KeyCode.Q;
}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
