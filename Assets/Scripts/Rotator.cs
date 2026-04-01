using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;

    void Update()
    {
        // 60 FPS => 1초에 60 번 => 업데이트 60번
        // 30 FPS => 1초에 30 번 => 업데이트 30번
        // Debug.Log(Time.deltaTime);
        transform.Rotate(
            0f, 
            rotationSpeed * Time.deltaTime, 
            0f
        );
    }
}
