using UnityEngine;

public class Module_AttackRanged : MonoBehaviour
{
    public Bullet m_Bullet;
    public void ShootOnDirection(Vector3 l_ShootPosition, Quaternion l_ShootDirection, float l_ShootSpeed, float l_Damage, string l_TagToKill)
    {
        Quaternion l_BulletDirection = l_ShootDirection;
        Bullet l_Bullet = m_Bullet;
        l_Bullet.m_Damage = l_Damage;
        l_Bullet.m_Speed = l_ShootSpeed;
        l_Bullet.m_TagToKill = l_TagToKill;
        Instantiate(l_Bullet, l_ShootPosition, l_BulletDirection);
    }
}
