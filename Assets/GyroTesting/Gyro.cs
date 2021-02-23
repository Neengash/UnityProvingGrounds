using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
In this version of the gyro controller we face a problem when
working with euler angles. Even though the Y and Z axis work
as one would expect, the X axis shows an unexpected behaviour
in which the movement is restricted to a 180º arc, instead
of the full circumference (like the other two).
 */

public class Gyro : MonoBehaviour
{
    public Vector3 gyro;
    public Vector3 reference;
    public bool referenced = false;
    Quaternion myRotation;

    void Start() {
        Input.gyro.enabled = true;
    }

    void Update() {
        if (Input.touchCount > 0) {
            UpdateReference();
        }

        if (referenced) {
            gyro = Input.gyro.attitude.eulerAngles;
            transform.rotation = Quaternion.Euler(new Vector3(
                GetAngleDifference(gyro.y, reference.y),
                -1 * GetAngleDifference(gyro.x, reference.x),
                GetAngleDifference(gyro.z, reference.z)
            ));
        }
    }

    private float GetAngleDifference(float gyro, float reference) {
        return gyro - reference;
    }

    public void UpdateReference () {
        reference = Input.gyro.attitude.eulerAngles;
        referenced = true;
    }

}
