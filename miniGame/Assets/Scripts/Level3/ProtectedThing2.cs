using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectedThing2 : MonoBehaviour
{
    public float FootStepV = 2.0f;
    public float PersonStepV = 2.0f;
    public float VanishPostion = 5.0f;
    public Vector3 Position;

    private Object obj;
    void Start()
    {
        obj = Resources.Load("Prefabs/Walkman");

        StartCoroutine(StartStartRun());
    }

    private IEnumerator StartStartRun()
    {
        while (true)
        {
            GameObject walkMan = Instantiate(obj) as GameObject;

            walkMan.transform.parent = gameObject.transform;

           walkMan.transform.position = Position;

            ProtectedThing pt = walkMan.GetComponent<ProtectedThing>();

            pt.FootStepV = FootStepV;
            pt.VanishPostion = VanishPostion;

            yield return new WaitForSeconds(PersonStepV);
        }
    }

}
