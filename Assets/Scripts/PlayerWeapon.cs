using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float targetDistance;
    [SerializeField] Transform targetPoint;
    [SerializeField] RectTransform crosshair;
    [SerializeField] ParticleSystem[] laserShootingFXs;
    bool isFiring = false;    

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    void AimLasers()
    {
        Vector3 fireDirection = targetPoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);

        foreach (ParticleSystem particleSystem in laserShootingFXs)
        {
            particleSystem.transform.rotation = rotationToTarget;
        }
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPos);
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void OnFire(InputValue iv)
    {
        isFiring = iv.isPressed;
    }

    void ProcessFiring()
    {
        foreach (ParticleSystem particleSystem in laserShootingFXs)
        {
            ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
            emissionModule.enabled = isFiring;
        }
    }
}
