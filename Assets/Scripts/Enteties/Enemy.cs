using UnityEngine;

public class Enemy : Immobile
{
    [System.Serializable]
    public class ItemDrop
    {
        public int dropRate;
        public GameObject item;
    }

    public int health;
    public int damage;
    public int waveMinLevel = 0;

    public ItemDrop[] drops;

    [HideInInspector]
    public Transform player;
    private new AudioSource audio;

    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audio = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Death(true);
        }
    }

    private void DropItem()
    {

        int randomNumber = Random.Range(0, 101);
        ItemDrop drop = drops[Random.Range(0, drops.Length)];
        if (randomNumber < drop.dropRate)
        {
            Instantiate(drop.item, transform.position, transform.rotation, transform.parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Death(false);
        }
    }

    void Death(bool shouldDropItem = true)
    {
        if (shouldDropItem)
        {
            DropItem();
        }

        audio.Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, audio.clip.length);
    }
}
