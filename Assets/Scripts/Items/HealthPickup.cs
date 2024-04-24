using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount;

    private bool isConsumed = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isConsumed) {
            isConsumed = true;
            collision.gameObject.GetComponent<Player>().HealHealth(healthAmount);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, audio.clip.length);
        }
    }
}
