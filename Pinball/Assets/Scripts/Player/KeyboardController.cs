using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : BaseController
{
    protected override bool CheckLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    }

    protected override bool CheckRight()
    {
        return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }
}
