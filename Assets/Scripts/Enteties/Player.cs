using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int fuel;
    public float speed = 10;
    public int maxHealth = 10;
    public int maxFuel = 10;
    public float fuelConsumptionInterval = 5f;
    public int fuelConsumptionRate = 1;
    public Image[] tires;
    public Sprite fullTire;
    public Sprite emptyTire;

    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private float fuelConsumptionTimer = 0f;
    private Slider feulBar;
    private new AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feulBar = FindObjectOfType<Slider>();
        feulBar.maxValue = maxFuel;
        feulBar.value = fuel;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        UpdateTireUI(health);
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

        feulBar.value = fuel;
    }

    public void TakeDamage(int damageAmount)
    {
        health = health - damageAmount < 0 ? 0 : health - damageAmount;
        UpdateTireUI(health);
        audio.Play();
    }

    public void HealHealth(int healAmount)
    {
        int totalHealth = health + healAmount;
        health = totalHealth > maxHealth ? maxHealth : totalHealth;
    }

    public void RefuelFuel(int refuelAmount)
    {
        int totalFuel = fuel + refuelAmount;
        fuel = totalFuel > maxFuel ? maxFuel : totalFuel;
    }

    void UpdateTireUI(int currentHealth)
    {
        for (int i = 0; i < tires.Length; i++)
        {
            if (i < currentHealth)
            {
                tires[i].sprite = fullTire;
            }
            else tires[i].sprite = emptyTire;
        }
    }
}
