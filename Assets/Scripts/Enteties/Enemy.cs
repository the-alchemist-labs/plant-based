using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    public int dropChance;
    public GameObject[] drops;

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
        if (randomNumber < dropChance) {
            GameObject drop = drops[Random.Range(0, drops.Length)];
            Instantiate(drop, transform.position, transform.rotation);
        }
    }
}
 