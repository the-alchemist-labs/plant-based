using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int fuel;

    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private float speed = 10;

    private float fuelConsumptionTimer = 0f;
    private float fuelConsumptionInterval = 5f;
    private int fuelConsumptionRate = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        UpdateFuel();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    void UpdateFuel()
    {
        fuelConsumptionTimer += Time.deltaTime;

        if (fuel > 0 && fuelConsumptionTimer >= fuelConsumptionInterval)
        {
            fuel -= fuelConsumptionRate;
            print(fuel);
            fuelConsumptionTimer = 0f;
        }
    }
}
