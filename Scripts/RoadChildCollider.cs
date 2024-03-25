using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChildCollider : MonoBehaviour
{
    private RailRoadScript rScript;
    private void Awake()
    {
        rScript = gameObject.GetComponentInParent<RailRoadScript>();
    }
    public void OnMouseDown()
    {
        if (rScript.mainScript.isBuildRailOpen == true)
        {
            if (rScript.isRailBuild == false)
            {
                if (rScript.isRailSelected == false)
                { 
                    rScript.RoadSelect();
                }
            }
        }
    }
}
