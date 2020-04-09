using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private float xMove;
    private float yMove;
    bool jump;

    NinjaModel theModel;

    void Start()
    {
        theModel = GetComponent<NinjaManager>().theModel;
        theModel.SetCharacterController(GetComponent<NinjaController>());
    }

    void Update()
    {
        // Input
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");
    }

    // Physics always should be in FixedUpdate
    void FixedUpdate()
    {
        theModel.Move(xMove, yMove, jump); // Pass input to model.
    }
}
