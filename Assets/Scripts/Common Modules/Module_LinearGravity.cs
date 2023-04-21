using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_LinearGravity : MonoBehaviour
{
    public static Vector3 SetGravityToVector(Vector3 l_Vector)
    {

        l_Vector.y = l_Vector.y + Physics.gravity.y;

        return l_Vector;
    }
}
