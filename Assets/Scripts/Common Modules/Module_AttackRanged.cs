using UnityEngine;

public class Module_AttackRanged : MonoBehaviour
{
    public void ShootOnDirection(Vector3 l_ShootPosition, Vector3 l_ShootDirection, float l_ShootSpeed, float l_Damage)
    {
        /*
         * Crear Object Bullet
         * Settear Speed y Damage en el bullet
         */

        Quaternion l_Direction = Quaternion.LookRotation(l_ShootDirection);
        Instantiate(null /*Gameobject bala*/, l_ShootPosition, l_Direction);
    }
}
