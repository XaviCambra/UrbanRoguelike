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
    public KeyCode m_LeftShiftKey = KeyCode.LeftShift;  //Crouch
    public KeyCode m_SpaceKey = KeyCode.Space;     //Item


}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
