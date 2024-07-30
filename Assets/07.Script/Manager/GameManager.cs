using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }
    
    public int RevolverMagazine = 6; 
    public int M1911Magazine = 12;

}
