using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaManager : MonoBehaviour
{
    // Since the model isn't a monobehaviour it needs a monobehaviour container to store and initialize it.
    public NinjaModel theModel;

    void Awake()
    {
        // Create model and supply view.
        theModel = new NinjaModel();
        theModel.SetView(GetComponent<NinjaView>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
