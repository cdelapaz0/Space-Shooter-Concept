using UnityEngine;
using System;
using System.Collections;

public static class CameraExtension {
	
	public static Rect worldSpaceRect( this Camera cam ) {

		float left = cam.ViewportToWorldPoint( new Vector3(0, 0, 0) ).x;
		
		float right = cam.ViewportToWorldPoint( new Vector3(1, 1, 0) ).x;
		
		float top = cam.ViewportToWorldPoint( new Vector3(0, 0, 0) ).y;
		
		float bottom = cam.ViewportToWorldPoint( new Vector3(1, 1, 0) ).y;

		Rect bounds = new Rect();
		bounds.xMin = left;
		bounds.xMax = right;
		bounds.yMin = top;
		bounds.yMax = bottom;


		return bounds;
	}
}
