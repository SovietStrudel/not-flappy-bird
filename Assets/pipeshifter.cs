using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeshifter : MonoBehaviour

{
	public float pipeSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
		if (transform.position.x <= -11) {
			Destroy(gameObject);
		}
    }
}
