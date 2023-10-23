using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerEffects : MonoBehaviour
{
    public static PlayerEffects Instance;
    [SerializeField]
    private Rigidbody _playerRB;
    private Vector3 _bouncebackDirection;
    [SerializeField]
    private float _knockBackStrength = 500f;
    [SerializeField]
    private ParticleSystem MoveParticle;
    private PlayerController _playerController;
    [SerializeField]
    private GameObject particleParent;

    private void Awake()
    {
        makeInstance();
    }

    private void OnDisable()
    {
        Instance = null;
    }

    void makeInstance()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      
        playTrailEffect();
    }

    public void HurtEffect()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void CancleHurtEffect()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void BounceBackEffect(Collision other)
    {
        _bouncebackDirection = transform.position - other.transform.position;
        _playerRB.AddForce(_bouncebackDirection.normalized*_knockBackStrength,ForceMode.Impulse);
        
    }

    public void playTrailEffect()
    {
       // particleParent.transform.position = -transform.position;
        ParticleSystem.ShapeModule shape = MoveParticle.shape;
        //   shape.position = this.transform.InverseTransformDirection(transform.position);
       // shape.position = -_playerController.CameraRelativeMovement;

          print(_playerController.CameraRelativeMovement.magnitude);
        MoveParticle.Play();
    }


}
