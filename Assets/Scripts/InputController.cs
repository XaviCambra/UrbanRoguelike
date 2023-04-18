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
    public KeyCode m_Crouch = KeyCode.LeftShift;


    public int MouseButton(MouseButton button)
    {
        switch (button)
        {
            case global::MouseButton.Left:
                return 0;

            case global::MouseButton.Center:
                return 2;

            case global::MouseButton.Right:
                return 1;

            default:
                return -1;
        }
    }


}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
