using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour {

    public int row { get; set; }
    public int col { get; set; }
    public string type;
    public BonusType bounsType;

    // Update is called once per frame
   public Shape()
    {
        this.bounsType = BonusType.None;
    }

    public bool IsSameType(Shape item)
    {
        return this.type.Equals(item.type);
    }

    public void Assign(string type, int row, int col)
    {
        this.type = type;
        this.row = row;
        this.col = col;
    }

    public void swap(Shape a, Shape b)
    {
        int TempRow, TempCol;
        TempRow = a.row;
        TempCol = b.col;
        a.row = b.row;
        a.col = b.col;
        b.row = TempRow;
        b.col = TempCol;
    }
}
