using UnityEngine;

public class DartBehavior : MonoBehaviour
{
    [SerializeField] float dartSpeed = 10f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += dartSpeed * Time.deltaTime * Vector3.forward;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject, 1f);
        }
    }
}
