using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody bulletRigidbody;
    private float speed = 8;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.Die();
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
