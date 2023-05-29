using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public BaseItem m_BaseItem;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            m_BaseItem.ApplyEffectItem();
            gameObject.SetActive(false);
        }
    }
}
