using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class MatchesInfo : BaseInfo {

    private List<GameObject> matchCandies
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

    public BonusType BonusContained;


    public MatchesInfo() : base()
    {
        BonusContained = BonusType.None;
    }

    public IEnumerable<GameObject> MatchedCandy
    {
        get
        {
            return matchCandies.Distinct();
        }
    }

    public void AddObjectRange(IEnumerable<GameObject> list)
    {
        foreach(var item in list)
        {
            AddItem(item);
        }
    }
}
