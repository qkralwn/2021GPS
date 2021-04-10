using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shooting();
        }
    }

    void Shooting() {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(ray, out hit, 100, layer)) {
            if (hit.collider.gameObject.GetComponent<Monster>() != null) {
                hit.collider.gameObject.GetComponent<Monster>().Die();
            }
        }
    }
}