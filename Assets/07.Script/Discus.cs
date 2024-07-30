using UnityEngine;

public class Discus : MonoBehaviour
{ 
    private ShootManager _shootManager;
    [SerializeField] private AudioClip _audioClip;
    private GameObject sh;
    private AudioSource _audioSource;
    private Renderer _renderer;
    
    private float discusSpeed = 15.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
        sh = GameObject.Find("ShootManager");
        _shootManager = sh.GetComponent<ShootManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * discusSpeed * Time.deltaTime;

        if (transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _shootManager.SetSc(100);
            _audioSource.PlayOneShot(_audioClip);
            _renderer.material.color = Color.red;
            Destroy(gameObject, 0.5f);
        }
    }
}
