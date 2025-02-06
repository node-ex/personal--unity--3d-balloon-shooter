using UnityEngine;

public class DartBehavior : MonoBehaviour
{
    [SerializeField] float dartSpeed = 10f;
    [SerializeField] GameObject balloonPrefab;

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
            GameManager.BalloonPopped?.Invoke();
            Destroy(collision.gameObject);
            Destroy(gameObject, 1f);
            Destroy(Instantiate(balloonPrefab, collision.transform.position, collision.transform.rotation), 1f);
        }
    }
}
