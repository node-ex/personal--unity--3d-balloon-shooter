using UnityEngine;

public class DartBehavior : MonoBehaviour
{
    [SerializeField] float dartSpeed = 10f;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.position += dartSpeed * Time.deltaTime * Vector3.forward;
    }
}
