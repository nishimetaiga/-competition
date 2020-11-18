using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking: MonoBehaviour
{
    public Camera camera;
    void LateUpdate()
    {
        //　カメラと同じ向きに設定
        transform.rotation = camera.transform.rotation;
    }
}
