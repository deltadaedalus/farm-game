using UnityEngine;
using System.Collections;

public class Util
{
    public static int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}