
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, -90));
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
