using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(0, 1, 0);
        }
    }
}
