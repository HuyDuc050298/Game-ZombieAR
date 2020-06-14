using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rote : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCursor();
    }
    void LookAtCursor()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        //{
        //    target = hit.point;
        //}

        //transform.LookAt(target);
    }

}
