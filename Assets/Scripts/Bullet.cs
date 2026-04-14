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

        PlayerController playerController = FindFirstObjectByType<PlayerController>();
        if (playerController != null) { 
            // 총알이 Player를 따라가게 구현
            Vector3 dir = playerController.transform.position - transform.position;
            // 방법 #2
            bulletRigidbody.linearVelocity = dir.normalized * speed;
        }
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
