using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 movement;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [SerializeField] float rollAngle;
    [SerializeField] float pitchAngle;
    [SerializeField] float rotationSpeed;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float roll = -rollAngle * movement.x;
        float pitch = -pitchAngle * movement.y;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        transform.localPosition += (Vector3)movement * speed * Time.deltaTime;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x, minX, maxX);
        float clampedYPos = Mathf.Clamp(transform.localPosition.y, minY, maxY);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos);
    }
}
