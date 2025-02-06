using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] GameObject dartPrefab;
    [SerializeField] Transform dartSpawner;
    bool canShoot = true;

    void Update()
    {
        Move();
        ShootDart();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += movementSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += movementSpeed * Time.deltaTime * Vector3.right;
        }
    }

    void ShootDart()
    {
        if (canShoot && Input.GetKey(KeyCode.Space))
        {
            Instantiate(dartPrefab, dartSpawner.position, dartSpawner.rotation);
            canShoot = false;
            Invoke(nameof(ResetCanShoot), 0.5f);
        }
    }

    void ResetCanShoot()
    {
        canShoot = true;
    }
}
