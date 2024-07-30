using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    //******************** 오큘러스 버튼 ********************//
    
    [SerializeField] protected OVRInput.Button shootButton; 
    [SerializeField] protected OVRInput.Button reloadButton;
    
    //*****************************************************//
    
    //******************** 컴포넌트 변수 선언 ********************//
    
    [SerializeField] protected AudioClip[] _audioClip;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform shootPoint;
    
    // Ui를 위한 변수
    [SerializeField] protected TMP_Text bulletCount;
    
    protected OVRGrabbable _grabbable;
    protected AudioSource _audioSource;
    protected Animator _animator;
    
    //********************************************************//
    
    //******************** 변수 선언 ********************//
    protected int magazine;
    protected int magazineAnimCount = 0;
    
    //*************************************************//
}
