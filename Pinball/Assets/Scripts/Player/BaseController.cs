using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    private bool left = false;
    private bool right = false;

    protected abstract bool CheckRight();
    protected abstract bool CheckLeft();

    // Update is called once per frame
    void Update()
    {
        left = CheckLeft();
        right = CheckRight();
    }

    public bool Left()
    {
        return left;
    }

    public bool Right()
    {
        return right;
    }
}
