using UnityEngine;

public class OilhPickup : Immobile
{
    public int fuelAmount;

    private bool isConsumed = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isConsumed) {
            isConsumed = true;
            collision.gameObject.GetComponent<Player>().RefuelFuel(fuelAmount);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, audio.clip.length);
        }
    }
}
