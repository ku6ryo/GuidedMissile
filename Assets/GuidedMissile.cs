using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if (target) {
        var force = target.transform.position - this.transform.position;
        this.transform.forward = force;
        var rb = this.GetComponent<Rigidbody>();
        if (rb) {
          rb.AddForce(force);
        }
      }
    }
}
