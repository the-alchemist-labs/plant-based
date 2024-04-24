using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class ItemDrop {
        public int dropRate;
        public GameObject item;
    }

    public int health;
    public int damage;

    public ItemDrop[] drops;

    [HideInInspector]
    public Transform player;

    public virtual void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            DropItem();
            Destroy(gameObject);
        }
    }

    private void DropItem() {
        int randomNumber = Random.Range(0, 101);
        ItemDrop drop = drops[Random.Range(0, drops.Length)];
        if (randomNumber < drop.dropRate) {
            Instantiate(drop.item, transform.position, transform.rotation);
        }
    }
}
 