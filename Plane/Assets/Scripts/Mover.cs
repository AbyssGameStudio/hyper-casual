using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	
	private Vector3 startPosition;
	private Vector3 targetPosition;
	private float duration = 5f;    
	private float elapsedTime = 0f;

	void Start()
	{
		startPosition = transform.position;

		targetPosition = startPosition + new Vector3(0, 0, -120);
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;

		float t = elapsedTime / duration;
		transform.position = Vector3.Lerp(startPosition, targetPosition, t);
		if (t >= 1f)
		{
			transform.position = targetPosition;
			this.enabled = false; 
			Destroy(gameObject);
		}
	}
}

