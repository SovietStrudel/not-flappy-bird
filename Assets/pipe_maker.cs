using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_maker : MonoBehaviour
{ 
	public GameObject pipePrefab;
	public GameObject scoretrigger;
	private GameObject top;
	private GameObject bottom;
	private float pipeHeight;
	public float pipeGap = 2f;
	public float pipeRange = 3f;
	public float interval = 1f;
	public float pipeDistance = 3;
	private float timer = 0f;
	void spawnpipe() {
		float random = Random.Range(-pipeRange, pipeRange);
			bottom =  Instantiate(pipePrefab, new Vector3(11,-(pipeHeight / 2) - pipeGap + random, 0), Quaternion.identity );
			top =  Instantiate(pipePrefab, new Vector3(11,(pipeHeight / 2) + pipeGap + random, 0), Quaternion.identity );
			Instantiate(scoretrigger, new Vector3(11, 0, 0), Quaternion.identity);
	}
    // Start is called before the first frame update
    void Start()
    {
		pipeHeight = pipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
		timer = interval;
		
      
    }

    // Update is called once per frame
    void Update()
    {
      timer -= Time.deltaTime;
	  if ( timer <= 0) {
	    spawnpipe(); 
		timer = interval;
	  }
	}
}
