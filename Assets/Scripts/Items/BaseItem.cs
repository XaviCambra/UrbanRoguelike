using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public virtual void ApplyEffectItem()
    {
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.m_Item = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController == null) return;

        playerController.GetComponent<PlayerController>().m_Item = this;

        gameObject.SetActive(false);
    }
}
