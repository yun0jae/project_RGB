using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

    public GameObject camera;

    public float smoothTime = 7f;

    public Transform Target;

    private Vector3 velocity = Vector3.zero;

    public static bool isActive = false;

    private int PassCount = 0;

    Vector3 targetPos = new Vector3(59.12f, 100.1852f, -7.81f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        

        if(Vector3.Distance(targetPos, camera.transform.position) < 0.1f)
        {
            //Quaternion quat = Quaternion.Euler(new Vector3(0, 90, 0));
            //camera.transform.rotation = Vector3.SmoothDamp(camera.transform.rotation, quat, ref velocity, 2);
            camera.transform.position = targetPos;
        } else
        {
        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPos, ref velocity, smoothTime);    
        }

    }



}
