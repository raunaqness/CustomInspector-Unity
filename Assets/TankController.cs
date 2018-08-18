using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    // Movement Stuff
    [Header("Tank Movement")]
    public int playerNumber = 1;

    [Range(10f, 50f)]
    public int speed = 20;

    [Range(90f, 150f)]
    public int turnSpeed = 120;

    [Range(5f, 50f)]
    public float velocity = 20f;

    private string movementAxisName;          // The name of the input axis for moving forward and back.
    private string turnAxisName;              // The name of the input axis for turning.
    private Rigidbody rb;                     // Reference used to move the tank.
    private float movementInputValue;         // The current value of the movement input.
    private float turnInputValue;             // The current value of the turn input.
    private float originalPitch;              // The pitch of the audio source at the start of the scene.


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
    private float m_CurrentHealth;                      // How much health the tank currently has.
    [SerializeField]
    private bool m_Dead;                                // Has the tank been reduced beyond zero health yet?

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

    // GUIButton Functions

    public void CreateTank(int TankNumber)
    {
        Debug.Log("Tank 1 Created!");    
    }

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
        // Store the value of both input axes.
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);

        //EngineAudio();
    }

    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }

    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.up * movementInputValue * speed * Time.deltaTime * -1;

        // Apply this movement to the rigidbody's position.
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = turnInputValue * turnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);
    }





}
