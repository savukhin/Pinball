using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : BaseController
{
    protected override bool CheckLeft()
    {
        return Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2;
    }

    protected override bool CheckRight()
    {
        return Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2;
    }
}
