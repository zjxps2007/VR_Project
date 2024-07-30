using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 70.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}