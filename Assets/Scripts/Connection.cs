using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private scr_Map.ConnectionData data;
    public int id;

    public void GiveData(scr_Map.ConnectionData _data)
    {
        data = _data;
        Connect();
    }

    private void Connect()
    {
        //Calculate, which corners are closest together
        //Draws a line between those 2 corners

		//first: get midpoint between two nodes
		//for each node check which corner is closest
		//connect those two corners

		Vector3 midPoint = data.nodeA.gameObject.transform.position - data.nodeB.gameObject.transform.position; //maybe rework
		float shortestDistance = float.MaxValue;
		Vector3[] connectionPoints = new Vector3[2];
		
		//check all corners of NodeA (save in connectionPoints[0])
		
		shortestDistance = float.MaxValue;
		
		//check all corners of NodeB (save in connectionPoints[1])
		
		//calculate midpoint between cornerA and CornerB
		midPoint = connectionPoints[0] - connectionPoints[1]; //maybe rework
		transform.position = midPoint;
		//rotate towards connectionPoints[0]
		float angle = Mathf.Atan2(connectionPoints[0].x, connectionPoints[0].y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		//rescale
		float scale = (midPoint - connectionPoints[0]).Distance;
		gameObject.transform.localScale = scale;
    }

    private void OnMouseOver()
    {
        
    }
}
