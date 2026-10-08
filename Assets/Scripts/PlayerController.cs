using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 5f;
    [SerializeField] private float boostSpeed = 35f;
    [SerializeField] ParticleSystem snowEffect, boostEffect;
    [SerializeField] ScoreManager scoreManager;

    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;

    float defaultSpeed;
    InputAction moveAction;
    Vector2 moveInput;
    float previousRotation, totalRotation;
    int flipCount;
    int activePowerUpsCount;
    

    private bool canControlPlayer = true; 
    public bool CanControlPlayer { get => canControlPlayer; set => canControlPlayer = value; }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        defaultSpeed = surfaceEffector2D.speed; //stores the initial speed of the SurfaceEffector2D component
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canControlPlayer) return;
        if (canControlPlayer)
        {
            PlayerTorque();
            BoostPlayer();
            CalculateFlips();
        }

    }

/// <summary>
/// calculates amount of flips inair
/// </summary>
    private void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        
        if(Math.Abs(totalRotation) >= 340f)
        {
            flipCount++;
            scoreManager.AddScore(flipCount*100);
            totalRotation = 0;
        }

        previousRotation = currentRotation;
    }

    public void ApplyPowerUp(PowerUpScriptableObject powerUpData)
    {
        activePowerUpsCount++;
        if (powerUpData.PowerUpType == "Speed")
        {
            defaultSpeed += powerUpData.PowerUpValue;
            boostSpeed += powerUpData.PowerUpValue;
        }
    }

    public void DeactivatePowerUp(PowerUpScriptableObject powerUpData)
    {
        activePowerUpsCount--;
        if (activePowerUpsCount == 0)
        {
            if (powerUpData.PowerUpType == "Speed")
            {
                defaultSpeed -= powerUpData.PowerUpValue;
                boostSpeed -= powerUpData.PowerUpValue;
            }
        }

    }

    /// <summary>
    /// Based on the horizontal input, apply torque to the Rigidbody2D to rotate the player
    /// </summary>
    void PlayerTorque()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0)
        {
            rb.AddTorque(torqueAmount);
        }
        else if (moveInput.x > 0)
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        // Increases player's speed when the arrow key is pressed, surface effector is increased to boostSpeed
        if (moveInput.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = defaultSpeed;
        }

    }

    void OnCollisionEnter2D(Collision2D collission)
    {
        int layerIndex= LayerMask.NameToLayer("Floor");
        if (collission.gameObject.layer == layerIndex)
        {
            if(moveInput.y > 0)
            {
                if (boostEffect.isPlaying == false)
                {
                    boostEffect.Play();
                }
            }
            else
            {
                if (snowEffect.isPlaying == false)
                {
                    snowEffect.Play();
                }
            }
            
        }
    }

    void OnCollisionExit2D(Collision2D collission)
    {
        int layerIndex= LayerMask.NameToLayer("Floor");
        if (collission.gameObject.layer == layerIndex)
        {
            snowEffect.Stop();
            boostEffect.Stop();
        }
    }

}
