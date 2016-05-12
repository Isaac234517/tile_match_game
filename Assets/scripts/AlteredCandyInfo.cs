using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AlteredCandyInfo : BaseInfo {

	protected List<GameObject> newCandy
    {
        get
        {
            return infos;
        }

        set
        {
            infos = value;
        }
    }

    public int maxDistinct;

    public AlteredCandyInfo():base()
    {
    }

    public void AddCandy(GameObject item)
    {
        AddItem(item);
    }

    public IEnumerable<GameObject> AlteredCandy
    {
        get
        {
            return newCandy.Distinct();
        }
    }
}
