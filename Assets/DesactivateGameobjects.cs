using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateGameobjects : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Forniture" || collision.gameObject.tag == "Kill Player")
        collision.gameObject.SetActive(false);
    }


}
