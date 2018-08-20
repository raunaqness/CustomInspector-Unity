using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public GameObject TankBlack;
    public GameObject TankRed;
    public GameObject TankBlue;

    // Movement Stuff
    [Header("Tank Movement")]
    public int playerNumber = 1;

    [Range(10f, 50f)]
    public int speed = 20;

    [Range(90f, 150f)]
    public int turnSpeed = 120;

    [Range(5f, 50f)]
    public float velocity = 20f;

    private string movementAxisName;          
    private string turnAxisName;             
    private Rigidbody rb;                    
    private float movementInputValue;        
    private float turnInputValue;             
    private float originalPitch;              


    // Shooting Stuff
    [Space(10)]
    [Header("Tank Shooting")]
    public Rigidbody Shell1;
    public Rigidbody Shell2;

    public float MinLaunchForce = 5f;
    public float MaxLaunchForce = 25f;
    public float MaxChargeTime = 1.5f;

    // Health Stuff
    [Space(10)]
    [Header("Tank Health")]

    [Range(20f, 100)]
    [Tooltip("Health value between 0 and 100.")]
    public int health = 100;

    [Range(5f, 20f)]
    public float damageRadius = 15f;

    public string tankClass = "The best";

    [SerializeField]
    [Range(0f, 100f)]
    private float m_CurrentHealth;                      
    [SerializeField]
    private bool m_Dead;                                

    // Audio Stuff
    [Space(10)]
    [Header("Audio")]

    public AudioSource MovementAudio;

    public AudioClip EngineIdle;
    public AudioClip EngineDriving;
    public AudioClip ShootingAudioclip;
    public AudioClip FireAudioclip;

    // Audio Stuff

    [Space(10)]
    [Header("Custom Editor Elements")]


    [HideInInspector]
    public Texture Tank_Red;
    [HideInInspector]
    public Texture Tank_Black;
    [HideInInspector]
    public Texture Tank_Blue;

    // Context Menu Functions

    [ContextMenu("Difficulty - Normal")]
    void SetDifficultyNormal()
    {
        health = 100;
        velocity = 20f;
        damageRadius = 15f;
        tankClass = "Bruiser";
    }

    [ContextMenu("Difficulty - Dark Souls")]
    void SetDifficultyDarkSouls()
    {
        health = 100;
        velocity = 12f;
        damageRadius = 25f;
        tankClass = "Overwatch";
    }

    // GUIButton Functions

    public void CreateTank(string TankColor)
    {
        GameObject NewTank;

        switch(TankColor){
            case "Red" :
                NewTank = Instantiate(TankRed);
                break;

            case "Blue":
                NewTank = Instantiate(TankBlue);
                break;

            case "Black":
                NewTank = Instantiate(TankBlack);
                break;

            default:
                break;


        }

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = true;

        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void Start()
    {
        movementAxisName = "Vertical";// + playerNumber;
        turnAxisName = "Horizontal";// + playerNumber;

        // Store the original pitch of the audio source.
        //m_OriginalPitch = m_MovementAudio.pitch;
    }

    private void Update()
    {
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);

        //EngineAudio();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.up * movementInputValue * speed * Time.deltaTime * -1;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
        rb.MoveRotation(rb.rotation * turnRotation);
    }





}
