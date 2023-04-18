using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public virtual void ApplyEffectItem()
    {
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.m_Item = null;
    }
}
