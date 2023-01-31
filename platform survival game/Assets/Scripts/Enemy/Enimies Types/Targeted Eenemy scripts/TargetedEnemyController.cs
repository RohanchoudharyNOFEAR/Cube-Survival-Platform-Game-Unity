using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedEnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;
    [SerializeField]
    private float ExplosionRadius = 10f;
    [SerializeField]
    private float ExplosionStrength = 5f;
    [SerializeField]
    private ParticleSystem ExplosionParticle;

    // [SerializeField]
    // private EnemyDataSO data;
  //  [SerializeField]
  //  private TargetedEnemyDataSO data;


    public GameObject Player;

   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Invoke("DestroyGameobject",6f);
    }

    // Update is called once per frame
    void Update()
    {
        Followplayer();
     //   DestroyGameobject();
    }

    void Followplayer()
    {  
             transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,speed*Time.deltaTime);     
    }
    private void DestroyGameobject()
    {
        PlayExplosionParticle();
        ExplosionEffect();
        Destroy(this.gameObject);
      
    }

    private void ExplosionEffect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach(Collider item in colliders)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if(rb!=null)
            {
                rb.AddExplosionForce(ExplosionStrength, transform.position, ExplosionRadius,0,ForceMode.Impulse);
            }
        }
    }

    private void PlayExplosionParticle()
    {
        ExplosionParticle.Play();
    }

}
