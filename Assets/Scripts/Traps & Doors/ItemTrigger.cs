using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public List<BaseItem> m_BaseItem;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetInnactiveWithTime(3);
            foreach (BaseItem item in m_BaseItem)
            {
                item.ApplyEffectItem();
            }
            gameObject.SetActive(false);
        }
    }
}
