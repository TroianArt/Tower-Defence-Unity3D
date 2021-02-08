using UnityEngine;

public class Points : MonoBehaviour {

	public static Transform[] points;
	void Awake ()
	{
		points = new Transform[transform.childCount];
		for (int i = 0; i < points.Length; i++)
		{
			Debug.Log(i);
			//Debug.Log(points[i].ToString());
			points[i] = transform.GetChild(i);
		}
	}

}
