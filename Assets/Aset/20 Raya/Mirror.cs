using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    
    public Transform Mirrorcam;
    public Transform Playercam;

    // Update is called once per frame
    void Update()
    {
        CalculateRotation();
    }

    public void CalculateRotation()
    {
        Vector3 dir = (Playercam.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;
        Mirrorcam.localRotation = rot;
    }
}
