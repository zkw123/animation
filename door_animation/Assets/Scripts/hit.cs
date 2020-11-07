using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class hit : MonoBehaviour
{
    public bool collider = false;
    private Vector3 deltaPos = Vector3.zero;
    public Transform camera;
    public Animator a;
    private Vector3 pos;
    int i = 0;
    int j = 0;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
    }
     void Update()
    {
        if(collider&& a.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            camera.localPosition -= deltaPos;

            deltaPos = Random.insideUnitSphere / 3.0f;

            camera.localPosition += deltaPos;
            i++;
            j++;

        }
        if (i == 50)
        {
            collider = false;
            i = 0;
        }
        if(j==500)
        {
            particle.SetActive(false);
            j = 0;
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        pos = contact.point;
        //pos = transform.position;
        collider = true;
        particle.SetActive(true);
        particle.transform.position = new Vector3(pos.x,pos.y,pos.z);
        particle.transform.forward = collision.transform.forward;
    }
}
