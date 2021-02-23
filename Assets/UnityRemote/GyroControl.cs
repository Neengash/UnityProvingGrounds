using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
That's the system that worked in the end.
It uses a parent object (of the parent object we use for the cammera)
 - resulting in "game object" > "game object" > "camera" -
to achieve the desired rotations.
 */

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    private void Start() {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro() {
        if (SystemInfo.supportsGyroscope) {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }
    private void Update() {
        if (gyroEnabled) {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
