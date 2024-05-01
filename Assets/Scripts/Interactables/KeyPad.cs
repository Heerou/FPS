using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactables
{
    [SerializeField]
    GameObject door;
    bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
