using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GuidedMissile : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision other) {
      var target = GameObject.Find("Target");
      if (other.gameObject == target) {
        var exp = GameObject.Find("Explosion");
        var top = this.transform.Find("Top");
        if (top != null && exp != null) {
          var copy = GameObject.Instantiate(exp) as GameObject;
          copy.transform.position = top.position;
        }
        Destroy(this.gameObject);
      }
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
