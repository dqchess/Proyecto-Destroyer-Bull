using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour {

		//This script will allow you to select two colors, and change the duration time that these two colors will blend it and create a nice, colorful background fade.

		public Color color1 = Color.red;
		public Color color2 = Color.blue;
		public float duration = 3.0F;

		Camera cam;

		void Start()
		{
			cam = GetComponent<Camera>();
			cam.clearFlags = CameraClearFlags.SolidColor;
		}

		void Update()
		{
			float t = Mathf.PingPong(Time.time, duration) / duration;
			cam.backgroundColor = Color.Lerp(color1, color2, t);
		}
	}