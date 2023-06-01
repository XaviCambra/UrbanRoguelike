using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misile : MonoBehaviour
{
    public GameObject m_Misile;
    [SerializeField] private float m_Damage;
    public float m_TimeToFallDown;
    private bool m_Fall = false;
    [SerializeField] public float m_FallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FallDown());
    }

    private void Update()
    {
        if (m_Fall)
            transform.Translate(Vector3.down * m_FallSpeed * Time.deltaTime);
    }

    private IEnumerator FallDown()
    {
        yield return new WaitForSeconds(m_TimeToFallDown);
        m_Fall = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            Destroy(m_Misile);
            return;
        }

        if(other.GetComponent<Module_Health>() != null)
        {
            other.GetComponent<Module_Health>().TakeDamage(m_Damage);
        }
    }
}
