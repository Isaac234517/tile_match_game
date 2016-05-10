using UnityEngine;
using System.Collections;

public enum BonusType
{
    None,
    DestroyWholeRowColumn
}


public static class BonusTypeUtilities
{
    public static bool ContainDestroyWholeRow(BonusType bt)
    {
        return (bt & BonusType.DestroyWholeRowColumn)
            == BonusType.DestroyWholeRowColumn;
    }
}

public enum GameState
{
    None,
    SelectionStarted,
    Animating
}