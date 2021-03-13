using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceActivator : MonoBehaviour
{
    public GameObject foo;

    void Start() {
        Debug.Log("Started");
        int a = 1 + 1;
        Debug.Log(a);
        doSomething();
    }

    void Update() {
        foo.SetActive(!Input.GetKey(KeyCode.Space));
    }

    void doSomething() {
        doSomethingAgain();
    }

    void doSomethingAgain() {
        int i = 0;
        int j = 1;
        Debug.Log(i+j);
    }
}
