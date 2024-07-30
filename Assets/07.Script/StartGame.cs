using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            canvas.SetActive(true);
        }
    }
}
