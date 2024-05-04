using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private bool attacked = false;
    
    public void Toggle()
    {
        attacked = !attacked;
    }

    public bool IsAttacked()
    {
        return attacked;
    }
}
