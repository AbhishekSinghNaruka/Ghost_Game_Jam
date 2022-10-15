using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float recoilForce = 10f;
    [SerializeField] public float rotationSpeed = 1f;
    [SerializeField] public float reloadTime = 60f;
    private float reloadTimeRem;
    private float fire;
    private float rotationMovement;

    //TODO: Restrict Movement upto 180 degree only and update that restrictions after shooting
    void Start()
    {
        reloadTimeRem = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        fire = Input.GetAxisRaw("Fire1");
        rotationMovement = Input.GetAxisRaw("Horizontal");
        
    }

    private void FixedUpdate()
    {
        Debug.Log(reloadTimeRem);
        if (reloadTimeRem > 0f) {
            reloadTimeRem--;
        }
        if (rotationMovement > 0.1f || rotationMovement < -0.1f) {
            float degree = rotationSpeed * rotationMovement;
           // Debug.Log(Mathf.Deg2Rad * degree);
            rb.AddTorque(Mathf.Deg2Rad *degree, ForceMode2D.Impulse);
        }

        if (fire > 0.1f && reloadTimeRem ==0) {
            float xForce = fire * Mathf.Sin(Mathf.Deg2Rad * rb.rotation) * recoilForce;
            float yForce = -fire * Mathf.Cos(Mathf.Deg2Rad * rb.rotation) * recoilForce;
            rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
            reloadTimeRem = reloadTime; 
        }
    }
}
