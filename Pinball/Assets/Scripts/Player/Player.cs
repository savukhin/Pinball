using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Kicker leftKicker;
    [SerializeField] private Kicker rightKicker;
    [SerializeField] private BaseController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.Left())
            leftKicker.Activate();
        else
            leftKicker.Deactivate();
        if (controller.Right())
            rightKicker.Activate();
        else
            rightKicker.Deactivate();
    }
}
