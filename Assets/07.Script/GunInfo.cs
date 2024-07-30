using UnityEngine;


[CreateAssetMenu(menuName = "GunObject/NewGun")]
public class GunInfo : ScriptableObject
{
    public string gunName;
    public float damage;
    public GameObject bullet;
}
