using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BaseInfo
{

    protected List<GameObject> infos;

    public BaseInfo()
    {
        this.infos = new List<GameObject>();
    }

    protected void AddItem(GameObject item)
    {
        if (!this.infos.Contains(item))
        {
            this.infos.Add(item);
        }
    }
}

