﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    [Header("Props")]
    public GameObject Crate;
    public GameObject TrafficCone;
    public GameObject Board;
    public GameObject Wheel;
    public GameObject OilDrum;

    // Movement Stuff
    [Header("Tank Movement")]
    public int playerNumber = 1;

    [Range(5f, 50f)]
    public int speed = 15;

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
    public GameObject Shell1;
    public Transform shootingPosition;

    [Range(1000f, 2000f)]
    public float shootForce = 1000;

    public float MinLaunchForce = 5f;
    public float MaxLaunchForce = 25f;
    public float MaxChargeTime = 1.5f;

    // Health Stuff
    [Space(10)]
    [Header("Tank Health")]

    [Range(20f, 100)]
    [Tooltip("Health value between 0 and 100.")]
    public int maximumHealth = 100;

    public string tankClass = "The best";

    [SerializeField]
    [Range(0f, 100f)]
    private float m_CurrentHealth;                      
    [SerializeField]
    private bool m_Dead;                                

    // Audio Stuff
    [Space(10)]
    [Header("Audio")]

    public AudioSource TankAudioSource;
    public AudioClip ShootingAudioclip;

    [Space(10)]
    [Header("Custom Editor Elements")]

    //[HideInInspector]
    public Texture Thumbnail_Crate;
    //[HideInInspector]
    public Texture Thumbnail_OilDrum;
    //[HideInInspector]
    public Texture Thumbnail_Board;
    //[HideInInspector]
    public Texture Thumbnail_TrafficCone;
    //[HideInInspector]
    public Texture Thumbnail_Wheel;

    // Context Menu Functions
    [ContextMenu("Difficulty - Normal")]
    void SetDifficultyNormal()
    {
        maximumHealth = 100;
        velocity = 20f;
        tankClass = "Bruiser";
    }

    [ContextMenu("Difficulty - Dark Souls")]
    void SetDifficultyDarkSouls()
    {
        maximumHealth = 100;
        velocity = 12f;
        tankClass = "Overwatch";
    }

    // GUIButton Functions
    public void SpawnProp(string propname)
    {
        GameObject temp;
        switch (propname)
        {
            case "board":
                Debug.Log("board Instantiated");
                temp = Instantiate(Board);
                temp.GetComponent<Renderer>().material.color = Color.black;
                break;

            case "oil_drum":
                Debug.Log("oil_drum Instantiated");
                 temp = Instantiate(OilDrum);
                temp.GetComponent<Renderer>().material.color = Color.black;
                break;

            case "crate":
                Debug.Log("crate Instantiated");
                 temp = Instantiate(Crate);
                temp.GetComponent<Renderer>().material.color = Color.black;
                break;

            case "traffic_cone":
                Debug.Log("traffic_cone Instantiated");
                 temp = Instantiate(TrafficCone);
                temp.GetComponent<Renderer>().material.color = Color.black;
                break;

            case "wheel":
                temp = Instantiate(Wheel);
                temp.GetComponent<Renderer>().material.color = Color.black;
                Debug.Log("wheel Instantiated");
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
    }

    private void Update()
    {
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);

        TankShot();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void TankShot()
    {
        if (Input.GetButtonUp("Jump"))
        {
            Transform clone;
            clone = Instantiate(Shell1.transform, shootingPosition.position, shootingPosition.rotation);
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.up * shootForce * -1f);
            TankAudioSource.clip = ShootingAudioclip;
            TankAudioSource.Play();
        }    
    }

    private void Move()
    {
        Vector3 movement = transform.up * movementInputValue * speed * Time.deltaTime * -1f;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
