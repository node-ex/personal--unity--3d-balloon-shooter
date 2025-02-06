using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] GameObject dartPrefab;
    [SerializeField] Transform dartSpawner;

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
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(dartPrefab, dartSpawner.position, dartSpawner.rotation);
        }
    }
}
