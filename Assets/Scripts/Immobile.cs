using UnityEngine;


public class Immobile : MonoBehaviour
{
    public virtual void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        float backgroundSpeed = GameObject
        .FindGameObjectWithTag("GameController")
        .GetComponent<GameManager>()
        .scrollSpeed;
        transform.Translate(Vector3.left * Time.deltaTime * backgroundSpeed);
    }
}