using UnityEngine;


public class Immobile : MonoBehaviour
{
    private float backgroundSpeed;

    public virtual void Start()
    {
        backgroundSpeed = GameObject
        .FindGameObjectWithTag("GameController")
        .GetComponent<GameManager>()
        .scrollSpeed;

        Destroy(gameObject, 10);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * backgroundSpeed);
    }
}