using UnityEngine;

public class ShootRevolver : Shoot, IShootCtrl
{ 
    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트 가져옴
        _grabbable = GetComponent<OVRGrabbable>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponentInChildren<Animator>();

        // 초기화
        magazineAnimCount = 0;
        magazine = 6;
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
                _animator.SetInteger("GunDrum", magazineAnimCount);
                magazine -= 1;
                bulletCount.text = magazine.ToString();
                magazineAnimCount += 1;
            }
            else
            {
                _audioSource.PlayOneShot(_audioClip[1]);
            }
        }

        // 잡고 있을때만 재장전
        if (_grabbable.isGrabbed && OVRInput.GetDown(reloadButton, _grabbable.grabbedBy.GetController()))
        {
            magazine = 6;
            bulletCount.text = magazine.ToString();
            magazineAnimCount = 0;
            _animator.SetInteger("GunDrum", magazineAnimCount);
        }
    }
}