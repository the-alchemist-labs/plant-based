using UnityEngine;


public class Immobile : MonoBehaviour
{
    private float backgroundSpeed;

    public virtual void Start()
    {
        backgroundSpeed = GameObject
        .FindGameObjectWithTag("Background")
        .GetComponent<MoveLeft>()
        .speed;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * backgroundSpeed);
    }
}