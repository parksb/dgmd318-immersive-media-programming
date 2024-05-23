using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool isSuperPistol = false;

    [SerializeField]
    private float force = 10;

    [SerializeField]
    private Transform muzzle;

    [SerializeField]
    private GameObject bullet;

    private AudioSource audio;
    private bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shoot)
        {
            GameObject obj = Instantiate(bullet, muzzle.position, muzzle.rotation);
            if (this.isSuperPistol)
            {
                obj.tag = "SuperBullet";
            }
            obj.GetComponent<Rigidbody>().AddForce(force * muzzle.forward, ForceMode.Impulse);
            audio.PlayOneShot(audio.clip);
            Destroy(obj, 2);
            shoot = false;
        }
    }

    public void Fire()
    {
        shoot = true;
    }
}
