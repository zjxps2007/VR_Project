using UnityEngine;

public class ShootM1911 : Shoot, IShootCtrl
{
    [SerializeField] private Transform leftHand;
    
    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트 가져옴
        _grabbable = GetComponent<OVRGrabbable>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponentInChildren<Animator>();
        
        // 초기화
        magazine = 12;
    }

    // Update is called once per frame
    void Update()
    { 
        Shoot();
    }

    public void Shoot()
    {
        // 그랩하고 있을때만 총알 발사
        if (_grabbable.isGrabbed && OVRInput.GetDown(shootButton, _grabbable.grabbedBy.GetController()))
        {
            if (magazine != 0)
            {
                _audioSource.PlayOneShot(_audioClip[0]);
                Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                _animator.SetTrigger("Shoot");
                magazine -= 1;
                bulletCount.text = magazine.ToString();
            }
            else
            {
                _audioSource.PlayOneShot(_audioClip[1]);
            }
        }

        // 잡고 있을때만 재장전
        if (_grabbable.isGrabbed && OVRInput.GetDown(reloadButton, _grabbable.grabbedBy.GetController()))
        {
            magazine = 12;
            bulletCount.text = magazine.ToString();
        }
    }
}
