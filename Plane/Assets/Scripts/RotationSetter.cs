using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSetter : MonoBehaviour
{
	public PlaneController controller;
    void Update()
    {
			transform.rotation = Quaternion.Euler(new Vector3(controller.smoothTilt, 90, 0));
	}
}
