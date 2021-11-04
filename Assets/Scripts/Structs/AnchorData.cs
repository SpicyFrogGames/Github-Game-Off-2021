using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorData
{
    public GameObject anchor;
    public GameObject target;

    public AnchorData(GameObject anchor, GameObject target)
    {
        this.anchor = anchor;
        this.target = target;
    }
}
