using UnityEngine;
using UnityEngine.UI;

public class UIButtonCtrl : MonoBehaviour
{
    [SerializeField] private Button _buttonM1911;
    [SerializeField] private Button _buttonPistol;
    [SerializeField] private GameObject m1911;
    [SerializeField] private GameObject pistol;

    [SerializeField] private Transform m1911SpawnPoint;
    [SerializeField] private Transform pistolSpawnPoint;
    
    private void Start()
    {
        _buttonM1911.onClick.AddListener(OnM1911);
        _buttonPistol.onClick.AddListener(OnPistol);
    }
    
    private void OnM1911()
    {
        Instantiate(m1911, m1911SpawnPoint);
    }

    private void OnPistol()
    {
        Instantiate(pistol, pistolSpawnPoint);
    }
}