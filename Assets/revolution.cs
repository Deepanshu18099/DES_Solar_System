using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    readonly float G = 100f;
    GameObject[] celestials;

    public GameObject Center;

    
    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Gravity();
    }


    void Gravity()
    {
            foreach (GameObject b in celestials)
            {
               if(b != gameObject) {

                    float m1 = gameObject.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(gameObject.transform.position, b.transform.position);
                    gameObject.GetComponent<Rigidbody>().AddForce((G * m1 * m2 / (r * r)) * (b.transform.position - gameObject.transform.position).normalized);
               }
            }
    }

    void InitialVelocity()
    {
        GameObject b = Center;

                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(gameObject.transform.position, b.transform.position);
                    // printing the r
                    Debug.Log(r);

                    // give perpendicular velocities to the plannets Mathf.Sqrt(G * m2 / r)
                    Debug.Log(gameObject.transform.position);


                    gameObject.transform.LookAt(b.transform);
                    


                    Debug.Log(gameObject.name);
                    Debug.Log(gameObject.transform.position);

                    gameObject.GetComponent<Rigidbody>().velocity += gameObject.transform.right * Mathf.Sqrt(G * m2 / (r));
    }
}