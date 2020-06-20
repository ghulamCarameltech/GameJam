using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBall",5f);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * 25);
    }

    void DestroyBall()
    {
        Destroy(gameObject);
    }
}
