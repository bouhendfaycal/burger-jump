using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;
	public float FollowSpeed = 7f;
	private Vector3 velocity = Vector3.zero;


	void FixedUpdate()
	{
 
			if (target)
			{
				Vector3 newPosition = target.position;
				newPosition.z = -10;
				transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
			}
		 
	}
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{

//	public Transform target;
//	public float FollowSpeed = 2f;
//	private Vector3 velocity = Vector3.zero;
//	public int followThreshold = 2;


//	void FixedUpdate()
//	{
//		if (target.position.y + followThreshold > transform.position.y)
//		{
//			if (target)
//			{
//				Vector3 newPosition = target.position;
//				newPosition.z = -10;
//				newPosition.y += followThreshold;
//				transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
//			}
//		}
//	}
//}

