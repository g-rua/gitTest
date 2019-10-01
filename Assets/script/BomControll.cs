using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomControll : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private Vector3 vel;
    public bool nage;
    public int explosionCount;
    private int explosionTimer=0;
    public bool isExplosion;
    private int oneSecond = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(explosionTimer++>explosionCount*oneSecond)
        {
            //一定時間経過後爆発
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        transform.position += vel*Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="InstantExplosionPanel")
        {
            //特殊な床にあたったら即爆発
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(other.tag=="Player"&&nage)
        {
            //投げた状態でプレイヤーに当たったら即爆発
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void BomThrow(Vector3 invel)
    {
        nage = true;
        transform.parent = null;
        vel = invel;
    }

    

    public void SetVel(Vector3 invel)
    {
        vel = invel;
    }


}
