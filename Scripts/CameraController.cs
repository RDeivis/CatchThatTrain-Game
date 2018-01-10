﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	void FixedUpdate()
	{
		Vector3 newPosition = target.position;
		newPosition.z = -10f;

		transform.position = newPosition;
	}
}
