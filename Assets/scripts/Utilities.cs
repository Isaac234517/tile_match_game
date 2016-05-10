using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utilities{

	public static IEnumerable AnimatePotentialMatches(IEnumerable<GameObject> potentialMatches)
    {
        for (float i = 1f; i>=0.3f; i -= 0.1f)
        {
            foreach(var item in potentialMatches)
            {
                Color c = SetColorOpacity(item, i);
            }
            yield return new WaitForSeconds(Constants.OpacityAnimationFrameDelay);
        }

        for (float i = 0.3f; i <= 1f; i += 0.1f)
        {
            foreach(var item in potentialMatches)
            {
                Color c = SetColorOpacity(item, i);
            }
            yield return new WaitForSeconds(Constants.OpacityAnimationFrameDelay);
        }
    }

    //Modify the original code
    private static Color SetColorOpacity(GameObject item,float i)
    {
        Color c = item.GetComponent<SpriteRenderer>().color;
        c.a = i;
        return c;
    }


    public static IEnumerable<GameObject> GetPotentialMatches(ShapeArray shapes)
    {
        List<List<List<GameObject>>> matches = new List<List<List<GameObject>>>();
        for (int row =0; row<Constants.Rows;  row++)
        {
            for(int col =0;  col < Constants.Columns; col++)
            {
                var matche1 = CheckPotenialHorizontial1(row, col, shapes);
                var matche2 = CheckPotenialHorizontial2(row, col, shapes);
                var matche3 = CheckPotenialHorizontial3(row, col, shapes);
                var matche4 = CheckPotentialVertical1(row, col, shapes);
                var matche5 = CheckPotentialVertical2(row, col, shapes);
                var matche6 = CheckPotentialVertical3(row, col, shapes);
                if (matche1 != null) matches.Add(matche1);
                if (matche2 != null) matches.Add(matche2);
                if (matche3 != null) matches.Add(matche3);
                if (matche4 != null) matches.Add(matche4);
                if (matche5 != null) matches.Add(matche5);
                if (matche6 != null) matches.Add(matche6);

                if(matches.Count> 2)
                {
                    List<List<GameObject>> list = matches[UnityEngine.Random.Range(0, matches.Count)];
                    return list[UnityEngine.Random.Range(0, list.Count)];
                }
            }

            if(row == Constants.Rows/2 && matches.Count>0 && matches.Count < 3)
            {
                List<List<GameObject>> list = matches[UnityEngine.Random.Range(0, matches.Count)];
                return list[UnityEngine.Random.Range(0, list.Count)];
            }
        }

        return null;
    }

    public static bool VerticalOrHorizontialMatches(Shape item1, Shape item2)
    {
        //@TODO
        return (item1.col == item2.col || item1.row == item1.row) && (Mathf.Abs(item1.col - item2.col) == 1 || Mathf.Abs(item2.row - item2.row) == 1);
    }



    public static List<List<GameObject>> CheckPotenialHorizontial1(int row, int col, ShapeArray arr)
    {
        List<List<GameObject>> matches = new List<List<GameObject>>();

        if (col < Constants.Columns - 2)
        {
            if (arr[row,col].GetComponent<Shape>().IsSameType(arr[row,col + 1].GetComponent<Shape>()))
            {
                if(row >=1 && row <= Constants.Rows - 2 && col >=1 )
                {
                    if (arr[row - 1,col - 1].GetComponent<Shape>().IsSameType(arr[row,col].GetComponent<Shape>())){
                        List<GameObject> item = new List<GameObject>()
                        {
                             arr[row-1,col-1],
                             arr[row,col],
                             arr[row,col + 1],
                        };
                        matches.Add(item);
                    }

                    if(arr[row + 1,col - 1].GetComponent<Shape>().IsSameType(arr[row,col].GetComponent<Shape>()))
                    {
                        List<GameObject> item = new List<GameObject>()
                        {
                             arr[row+1,col-1],
                             arr[row,col],
                             arr[row,col + 1],
                        };
                        matches.Add(item);
                    }
                }
            }
        }
        return matches.Count>0? matches :null ;
    }

    public static List<List<GameObject>> CheckPotenialHorizontial2(int row, int col, ShapeArray arr)
    {
        List<List<GameObject>> matches = new List<List<GameObject>>();
        if(col < Constants.Columns -2 )
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row, col + 1].GetComponent<Shape>())){
                if(row >=1 && row<=Constants.Rows - 2)
                {
                    if(arr[row-1, col+2].GetComponent<Shape>().IsSameType(arr[row, col + 1].GetComponent<Shape>()))
                    {
                        List<GameObject> item = new List<GameObject>()
                        {
                            arr[row,col],
                            arr[row,col+1],
                            arr[row-1,col+2]
                        };
                        matches.Add(item);
                    }

                    if (arr[row + 1, col + 2].GetComponent<Shape>().IsSameType(arr[row, col + 1].GetComponent<Shape>()))
                    {
                        List<GameObject> item = new List<GameObject>()
                        {
                             arr[row,col],
                            arr[row,col+1],
                            arr[row+1,col+2]
                        };
                        matches.Add(item);
                    }
                }
            }
        }
        return matches.Count > 0? matches :null;
    }

    public static List<List<GameObject>> CheckPotenialHorizontial3(int row, int col, ShapeArray arr)
    {
        List<List<GameObject>> matches = new List<List<GameObject>>();
        if(col < Constants.Columns - 3)
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row, col + 1].GetComponent<Shape>()) && arr[row, col + 1].GetComponent<Shape>().IsSameType(arr[row, col + 3].GetComponent<Shape>()))
            {
                List<GameObject> item = new List<GameObject>()
            {
                arr[row,col],
                arr[row,col+1],
                arr[row,col+3]
            };
                matches.Add(item);
            }
        }
        
        if(col >= 2)
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row, col+1].GetComponent<Shape>()) && arr[row, col].GetComponent<Shape>().IsSameType(arr[row, col -2].GetComponent<Shape>()))
            {
                List<GameObject> item = new List<GameObject>()
            {
                arr[row,col],
                arr[row,col+1],
                arr[row,col-2]
            };
                matches.Add(item);
            }
        }
        return matches.Count > 0 ? matches : null;
    }

    public static List<List<GameObject>> CheckPotentialVertical1(int row, int col, ShapeArray arr)
    {
        List<List<GameObject>> matches = new List<List<GameObject>>();
        if(row < Constants.Rows - 2)
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row + 1, col].GetComponent<Shape>()))
            {
                if(col >0 && col < Constants.Columns - 1)
                {
                    if(arr[row + 1, col].GetComponent<Shape>().IsSameType(arr[row + 2, col + 1].GetComponent<Shape>())){
                        List<GameObject> item = new List<GameObject>()
                        {
                            arr[row,col],
                            arr[row+1,col],
                            arr[row+2,col+1]
                        };
                        matches.Add(item);
                    }

                    if (arr[row + 1, col].GetComponent<Shape>().IsSameType(arr[row + 2, col - 1].GetComponent<Shape>())){
                        List<GameObject> item = new List<GameObject>()
                        {
                            arr[row,col],
                            arr[row+1,col],
                            arr[row+2,col-1]
                        };
                        matches.Add(item);
                    }
                }
            }
        }
        return matches.Count > 0 ? matches : null;
    }

    public static List<List<GameObject>> CheckPotentialVertical2(int row, int col, ShapeArray arr)
    {
        List<List<GameObject>> matches = new List<List<GameObject>>();
        if(row < Constants.Rows - 1)
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row + 1, col].GetComponent<Shape>()))
            {
                if(col>0 && col < Constants.Columns - 1)
                {
                    if (arr[row + 1, col].GetComponent<Shape>().IsSameType(arr[row - 1, col - 1].GetComponent<Shape>()))
                    {
                        List<GameObject> item = new List<GameObject>()
                    {
                        arr[row,col],
                        arr[row+1,col],
                        arr[row-1,col-1]
                    };
                        matches.Add(item);
                    }

                    if (arr[row + 1, col].GetComponent<Shape>().IsSameType(arr[row - 1, col + 1].GetComponent<Shape>()))
                    {
                        List<GameObject> item = new List<GameObject>()
                    {
                        arr[row,col],
                        arr[row+1,col],
                        arr[row-1,col+1]
                    };
                        matches.Add(item);
                    }
                }
               
            }
        }
        return matches.Count > 0 ? matches : null;
    }

    public static List<List<GameObject>> CheckPotentialVertical3(int row, int col, ShapeArray arr)
    {
        List<List<GameObject>> matches = new List<List<GameObject>>();
        if (row < Constants.Rows - 3)
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row +1, col].GetComponent<Shape>()) && arr[row+1, col].GetComponent<Shape>().IsSameType(arr[row +3, col].GetComponent<Shape>()))
            {
                List<GameObject> item = new List<GameObject>()
            {
                arr[row,col],
                arr[row+1,col],
                arr[row+3,col]
            };
                matches.Add(item);
            }
        }

        if (row >= 2)
        {
            if (arr[row, col].GetComponent<Shape>().IsSameType(arr[row+1, col].GetComponent<Shape>()) && arr[row, col].GetComponent<Shape>().IsSameType(arr[row -2, col].GetComponent<Shape>()))
            {
                List<GameObject> item = new List<GameObject>()
            {
                arr[row,col],
                arr[row +1,col],
                arr[row -2,col]
            };
                matches.Add(item);
            }
        }
        return matches.Count > 0 ? matches : null;
    }
}
