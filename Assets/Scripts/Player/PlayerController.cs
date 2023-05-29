using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    public Player_BLACKBOARD m_Blackboard;
    InputController m_InputController;
    CharacterController m_CharacterController;

    Player_Health m_Health;
    Module_Crouch m_Crouch;
    Module_Dash m_Dash;
    Module_AttackRanged m_RangedAttack;
    Module_Animation m_Animation;

    private float m_MovementSpeed;

    [SerializeField] private GameObject m_Body;
    [SerializeField] private GameObject m_Hips;

    private void Start()
    {
        m_InputController = GetComponent<InputController>();
        m_Blackboard = GetComponent<Player_BLACKBOARD>();
        m_CharacterController = GetComponent<CharacterController>();
        m_Health = GetComponent<Player_Health>();
        m_Animation = GetComponent<Module_Animation>();
        m_RangedAttack = GetComponent<Module_AttackRanged>();
        m_Dash = GetComponent<Module_Dash>();
        m_Crouch = GetComponent<Module_Crouch>();
        
        m_MovementSpeed = m_Blackboard.m_MovementSpeed;

        StartCoroutine(Inmortality(m_Blackboard.m_InmortalityDuration));
    }

    private void Update()
    {
        if(m_Blackboard.m_CanInteract == false) return;
        
        if (m_Blackboard.m_CanMove) MovementInput();

        Crouching();
        if(!m_Blackboard.m_Crouching) Shoot();
        UseItem();
        SetSpeed();
        HipsFaceMouse();
    }

    void MovementInput()
    {
        Vector3 l_Direction = Vector3.zero;

        if (Input.GetKey(m_InputController.m_ForwardKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.forward;
        }
        if (Input.GetKey(m_InputController.m_BackKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.back;
        }
        if (Input.GetKey(m_InputController.m_LeftKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.left;
        }
        if (Input.GetKey(m_InputController.m_RightKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.right;
        }

        l_Direction.Normalize();

        if (Dash())
        {
            CancelMovementDash();
            return;
        }

        if (l_Direction == Vector3.zero)
        {
            //BodyFaceMouse();
            return;
        }
        //else HipsFaceMouse();

        

        l_Direction = Module_LinearGravity.SetGravityToVector(l_Direction);

        l_Direction = l_Direction * m_MovementSpeed * Time.deltaTime;

        m_CharacterController.Move(l_Direction);
    }

    private IEnumerator CancelMovementDash()
    {
        m_Blackboard.m_CanMove = false;
        yield return new WaitForSeconds(0.1f);
        m_Blackboard.m_CanMove = true;
    }

    private void Crouching()
    {
        if (Input.GetKeyDown(m_InputController.m_CrouchingKey))
        {
            m_Blackboard.m_Crouching = m_Crouch.Crouching(m_Blackboard.m_Crouching, 0.5f);
        }
    }

    void UseItem()
    {
        if (Input.GetKeyDown(m_InputController.m_UseItemKey))
        {
            if (m_Blackboard.m_Item == null) return;

            m_Blackboard.m_Item.ApplyEffectItem();
        }
    }

    void SetSpeed()
    {
        if (m_Blackboard.m_Crouching)
        {
            m_MovementSpeed = m_Blackboard.m_CrouchingSpeed;
        }
        else
        {
            m_MovementSpeed = m_Blackboard.m_MovementSpeed;
        }
    }

    private bool Dash()
    {
        if (Input.GetKeyDown(m_InputController.m_DashKey) == false) return false;

        if(m_Blackboard.m_DashCount >= m_Blackboard.m_DashMaxCount) return false;

        m_Dash.DashDisplacement(m_Hips.transform.forward, m_Blackboard.m_DashDistance, m_Blackboard.m_DashSpeed);

        m_Blackboard.m_DashCount++;

        StartCoroutine(DashReload());

        return true;
    }

    private IEnumerator DashReload()
    {
        yield return new WaitForSeconds(m_Blackboard.m_DashCooldown);
        m_Blackboard.m_DashCount--;
    }

    void BodyFaceMouse()
    {
        m_Body.transform.forward = m_InputController.m_MouseDirectionScreen();
        if (m_Body.transform.localRotation.y * Mathf.Rad2Deg > 40)
        {
            Quaternion l_HipsRotation = m_Body.transform.localRotation;
            l_HipsRotation.y -= 40 * Mathf.Deg2Rad;
            m_Hips.transform.localRotation = l_HipsRotation;
        }
        else if (m_Body.transform.localRotation.y * Mathf.Rad2Deg < -40)
        {
            Quaternion l_HipsRotation = m_Body.transform.localRotation;
            l_HipsRotation.y += 40 * Mathf.Deg2Rad;
            m_Hips.transform.localRotation = l_HipsRotation;
        }
    }

    void HipsFaceMouse()
    {
        //m_Body.transform.forward = m_InputController.m_MouseDirectionScreen();
        m_Hips.transform.forward = m_InputController.m_MouseDirectionScreen();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown((int) MouseButton.Left) && m_Blackboard.CanShoot())
        {
            m_RangedAttack.ShootOnDirection(m_Blackboard.m_ShootPoint.position, m_Blackboard.m_ShootPoint.transform.rotation, m_Blackboard.m_BulletSpeed, m_Blackboard.m_ShootingDamage, "Player");
            m_Blackboard.OverHeat();
        }
    }

    public void StartKillerMode()
    {
        StartCoroutine(CancelOverHeat());
    }

    public IEnumerator CancelOverHeat()
    {
        m_Blackboard.m_CanOverheat = false;
        Debug.Log("Overheat cancelled " + m_Blackboard.m_OverHeatCancelDuration + " seconds");
        yield return new WaitForSeconds(m_Blackboard.m_OverHeatCancelDuration);
        m_Blackboard.m_CanOverheat = true;
    }

    public IEnumerator Inmortality(float l_Duration)
    {
        m_Health.m_CanLooseHealth = false;
        yield return new WaitForSeconds(l_Duration);
        m_Health.m_CanLooseHealth = true;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Player_Health>().m_PlayerIsDead += SetInnactive;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Player_Health>().m_PlayerIsDead -= SetInnactive;
    }
    private void SetInnactive()
    {
        m_Blackboard.m_CanInteract = false;
    }

    public void SetInnactiveWithTime(float l_Duration)
    {
        StartCoroutine(SetInnactive(l_Duration));
    }

    public IEnumerator SetInnactive(float l_Duration)
    {
        m_Blackboard.m_CanInteract = false;
        yield return new WaitForSeconds(l_Duration);
        m_Blackboard.m_CanInteract = true;
    }
}
