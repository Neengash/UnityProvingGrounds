using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This version of the gyro controll logic seems to do the trick
but it has a problem, due to it working with rotate (so difference
in rotations of the gyro) it looses tiny bits of information
through the diferent iterations. This results in a situation where
having the mobile phone in the same position at two different
moments, doesn't keep the same camera orientation in the game.
 */

public class rotateY : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.02f;
    }

    private void FixedUpdate() {
        transform.Rotate (
            -Input.gyro.rotationRateUnbiased.x,
            -Input.gyro.rotationRateUnbiased.y,
            Input.gyro.rotationRateUnbiased.z);
    }
}
