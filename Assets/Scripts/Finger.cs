using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    private bool resize;
    // Start is called before the first frame update
    void Start()
    {
        resize = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 0f)
        {
            transform.position = transform.position + Vector3.left * 3f * Time.deltaTime;
        }
        else
        {
            if (transform.localScale.x > 0.2f && !resize)
            {
                transform.localScale = transform.localScale - Vector3.one * 0.3f * Time.deltaTime;
            }
            else
            {
                if (transform.localScale.x < 0.4f)
                {
                    resize = true;
                    transform.localScale = transform.localScale + Vector3.one * 0.3f * Time.deltaTime;
                }
                else
                {
                    resize = false;
                }
            }
        }

        if (Input.touchCount > 0 || Input.GetButton("Fire1"))
        {
            Destroy(gameObject);
        }
    }
}
