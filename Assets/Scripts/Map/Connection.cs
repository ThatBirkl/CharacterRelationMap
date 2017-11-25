using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private scr_Map.ConnectionData data;
    public int id;
    private Color originalColor;

    public void GiveData(scr_Map.ConnectionData _data)
    {
        data = _data;
        Connect();
    }

    private void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "Nodes";
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void Connect()
    {
        //Calculate, which corners are closest together
        //Draws a line between those 2 corners

		//first: get midpoint between two nodes
		//for each node check which corner is closest
		//connect those two corners

		Vector3 midPoint = data.nodeB.gameObject.transform.position + 
                            (data.nodeA.gameObject.transform.position - data.nodeB.gameObject.transform.position) / 2; //maybe rework
		float shortestDistance = float.MaxValue;
		Vector3[] connectionPoints = new Vector3[2];

        //check all corners of NodeA (save in connectionPoints[0])
        #region NodeA
        //lo, ro, ru, lu
        Vector3 corner = data.nodeA.transform.position;
        corner.x -= data.nodeA.GetComponent<Sprite>().border.x;
        corner.y += data.nodeA.GetComponent<Sprite>().border.w;
        float dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[0] = corner;
        }

        corner = data.nodeA.transform.position;
        corner.x += data.nodeA.GetComponent<Sprite>().border.z;
        corner.y += data.nodeA.GetComponent<Sprite>().border.w;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[0] = corner;
        }

        corner = data.nodeA.transform.position;
        corner.x += data.nodeA.GetComponent<Sprite>().border.z;
        corner.y -= data.nodeA.GetComponent<Sprite>().border.y;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[0] = corner;
        }

        corner = data.nodeA.transform.position;
        corner.x -= data.nodeA.GetComponent<Sprite>().border.x;
        corner.y -= data.nodeA.GetComponent<Sprite>().border.y;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[0] = corner;
        }
        #endregion

        shortestDistance = float.MaxValue;

        //check all corners of NodeB (save in connectionPoints[1])
        #region NodeB
        //lo, ro, ru, lu
        corner = data.nodeB.transform.position;
        corner.x -= data.nodeB.GetComponent<Sprite>().border.x;
        corner.y += data.nodeB.GetComponent<Sprite>().border.w;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[1] = corner;
        }

        corner = data.nodeB.transform.position;
        corner.x += data.nodeB.GetComponent<Sprite>().border.z;
        corner.y += data.nodeB.GetComponent<Sprite>().border.w;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[1] = corner;
        }

        corner = data.nodeB.transform.position;
        corner.x += data.nodeB.GetComponent<Sprite>().border.z;
        corner.y -= data.nodeB.GetComponent<Sprite>().border.y;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[1] = corner;
        }

        corner = data.nodeB.transform.position;
        corner.x -= data.nodeB.GetComponent<Sprite>().border.x;
        corner.y -= data.nodeB.GetComponent<Sprite>().border.y;
        dist = (midPoint - corner).magnitude;
        if (dist < 0) dist = -dist;
        if (dist < shortestDistance)
        {
            shortestDistance = dist;
            connectionPoints[1] = corner;
        }
        #endregion

        //calculate midpoint between cornerA and CornerB
        midPoint = connectionPoints[1] + (connectionPoints[0] - connectionPoints[1]) / 2; //maybe rework
		transform.position = midPoint;
		//rotate towards connectionPoints[0]
		float angle = Mathf.Atan2(connectionPoints[0].x, connectionPoints[0].y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		//rescale
		float scale = (midPoint - connectionPoints[0]).magnitude;
		gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, scale, 0);
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(originalColor.r + 0.30f, originalColor.g + 0.30f,
                                                        originalColor.b + 0.40f, originalColor.a);
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
