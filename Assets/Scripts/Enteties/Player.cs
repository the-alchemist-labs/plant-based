using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int fuel;
    public float speed = 10;
    public int maxHealth = 10;
    public int maxFuel = 10;
    public float fuelConsumptionInterval = 5f;
    public int fuelConsumptionRate = 1;

    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private float fuelConsumptionTimer = 0f;

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
            fuelConsumptionTimer = 0f;
        }
    }

    public void TakeDamage(int damageAmount) {
        health = health - damageAmount < 0 ? 0 : health - damageAmount;
        print(health);
    }

    public void HealHealth(int healAmount) {
        int totalHealth = health + healAmount;
        health = totalHealth > maxHealth ? maxHealth : totalHealth;
    }

    public void RefuelFuel(int refuelAmount)
    {
        int totalFuel = fuel + refuelAmount;
        fuel = totalFuel > maxFuel ? maxFuel : totalFuel;
    }
}
