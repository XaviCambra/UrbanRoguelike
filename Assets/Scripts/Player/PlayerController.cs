using System.Collections;
using UnityEngine;
using FMODUnity;
using System.Threading;
using UnityEditor;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    public Player_BLACKBOARD m_Blackboard;
    InputController m_InputController;
    CharacterController m_CharacterController;

    //Modules
    Player_Health m_Health;
    Module_Crouch m_Crouch;
    [SerializeField] Module_Dash m_Dash;
    Module_AttackRanged m_RangedAttack;
    Module_Animation m_Animation;

    public ShieldShaderController m_Shield;

    private float m_MovementSpeed;

    [SerializeField] private float l_MaxPerformanceAngle = 60.0f;
    [SerializeField] private float l_MultiPerformanceToAngle = 20.0f;

    [SerializeField] private Transform m_PlayerRotationPoint;
    [SerializeField] private Transform[] m_PlayerHipsRotationPoint;

    private int m_StepCounter = 50;

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

        StartCoroutine(Inmortality(3.0f));

        m_MovementSpeed = m_Blackboard.m_MovementSpeed;

    }

    private void Update()
    {
        if(m_Blackboard.m_CanInteract == false) return;
        if(Time.timeScale == 0) return;

        PauseGame();
        
        if (m_Blackboard.m_CanMove) MovementInput();

        Crouching();
        if(!m_Blackboard.m_Crouching) Shoot();
        UseItem();
        SetSpeed();
    }

    private void LateUpdate()
    {
        HipsFaceMouse();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(m_InputController.m_PauseButton))
        {
            Time.timeScale = 0;
            AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PauseMenuSound, transform.position);
            SceneLoader.LoadAdditiveScene("PauseMenu");
        }
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

        m_Animation.Play("MoveSpeed", m_Blackboard.m_Impulse);

        if (m_Blackboard.m_Impulse > 0)
            m_Animation.SetSpeed(m_Blackboard.m_Impulse);
        else
            m_Animation.SetSpeed(1);

        if (l_Direction == Vector3.zero)
        {
            m_Blackboard.m_Impulse = Mathf.Clamp(m_Blackboard.m_Impulse - Time.deltaTime * m_Blackboard.m_ImpulseSpeed, 0, 1);
            
            return;
        }
        m_Blackboard.m_Impulse = Mathf.Clamp(m_Blackboard.m_Impulse + Time.deltaTime * m_Blackboard.m_ImpulseSpeed, 0, 1);

        l_Direction = Module_LinearGravity.SetGravityToVector(l_Direction);

        l_Direction = l_Direction * m_MovementSpeed * m_Blackboard.m_Impulse * Time.deltaTime;

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
            m_Blackboard.m_CanMove = !m_Blackboard.m_Crouching;
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
            m_Animation.Play("Crouching", true);
        }
        else
        {
            m_MovementSpeed = m_Blackboard.m_MovementSpeed;
            m_Animation.Play("Crouching", false);
        }
    }

    private bool Dash()
    {
        if (Input.GetKeyDown(m_InputController.m_DashKey) == false) return false;

        if(m_Blackboard.m_DashCount >= m_Blackboard.m_DashMaxCount) return false;

        m_Dash.DashDisplacement(m_PlayerRotationPoint.transform.forward, m_Blackboard.m_DashDistance, m_Blackboard.m_DashSpeed);

        m_Blackboard.m_DashCount++;

        m_Animation.Play("Dash");

        StartCoroutine(DashReload());

        return true;
    }

    private IEnumerator DashReload()
    {
        yield return new WaitForSeconds(m_Blackboard.m_DashCooldown);
        m_Blackboard.m_DashCount--;
    }

    void HipsFaceMouse()
    {
        float l_AngleMouse = Mathf.Atan2(m_InputController.m_MouseDirectionScreen().z, m_InputController.m_MouseDirectionScreen().x) * Mathf.Rad2Deg;
        m_PlayerRotationPoint.localRotation = Quaternion.Slerp(m_PlayerRotationPoint.rotation, Quaternion.Euler(0, -l_AngleMouse, 0), 4.5f * Time.deltaTime);
        foreach (Transform l_HipsTransform in m_PlayerHipsRotationPoint)
        {
            float l_AngleDifference = l_AngleMouse - m_PlayerRotationPoint.localRotation.y * Mathf.Rad2Deg;
            float l_AngleDivision = l_AngleDifference / m_PlayerHipsRotationPoint.Length;
            Debug.Log("Total Angle = " + l_AngleMouse + " - " + m_PlayerRotationPoint.rotation.y * Mathf.Rad2Deg + " - Difference = " + l_AngleDifference + " - Divided by " + m_PlayerHipsRotationPoint.Length + " = " + l_AngleDivision);
            l_HipsTransform.localRotation = Quaternion.Euler(l_AngleDivision, 0, 0);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown((int)m_InputController.m_ShootButton) && m_Blackboard.CanShoot())
        {
            m_RangedAttack.ShootOnDirection(m_Blackboard.m_ShootPoint.position, m_Blackboard.m_ShootPoint.transform.rotation, m_Blackboard.m_BulletSpeed, m_Blackboard.m_ShootingDamage, "Player");
            if (FindObjectOfType<AudioManager>() != null)
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PlayerShoot, transform.position);

            m_Animation.Play("Shoot");
            m_Blackboard.OverHeat();
        }

        if (Input.GetMouseButtonDown((int)m_InputController.m_ShootButton) && !m_Blackboard.CanShoot())
        {
            if (FindObjectOfType<AudioManager>() != null)
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PlayerCantShoot, transform.position);
        }
    }

    public void StartKillerMode()
    {
        if (FindObjectOfType<AudioManager>() != null)
            AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_KillerModeSound, transform.position);
        StartCoroutine(CancelOverHeat());
    }

    public IEnumerator CancelOverHeat()
    {
        m_Blackboard.m_CanOverheat = false;
        yield return new WaitForSeconds(m_Blackboard.m_OverHeatCancelDuration);
        m_Blackboard.m_CanOverheat = true;
    }

    public void StartInmortality(float l_Duration)
    {
        m_Shield.Appear();
        if (FindObjectOfType<AudioManager>() != null)
            AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_ShieldAppearSound, transform.position);
        StartCoroutine(Inmortality(l_Duration));
    }

    private IEnumerator Inmortality(float l_Duration)
    {
        m_Health.m_CanLooseHealth = false;
        yield return new WaitForSeconds(l_Duration);
        m_Health.m_CanLooseHealth = true;
        EndInmortality();
    }

    private void EndInmortality()
    {
        m_Shield.Dissapear();
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

    public void FootSteps()
    {
        int i = Random.Range(0, 100);

        if (i > m_StepCounter)
        {
            if (FindObjectOfType<AudioManager>() != null)
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PlayerStep1, transform.position);
            m_StepCounter++;
        }
        else
        {
            if (FindObjectOfType<AudioManager>() != null)
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PlayerStep2, transform.position);
            m_StepCounter--;
        }
    }
}
