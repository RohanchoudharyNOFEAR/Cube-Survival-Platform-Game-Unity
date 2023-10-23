using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyRoute : MonoBehaviour
{
    [SerializeField] private Transform[] _controlPoints;
    private Vector3 _gizmoPosition;

    private void OnDrawGizmos()
    {
        for(float t =0; t<=1; t+=0.05f)
        {
            _gizmoPosition = Mathf.Pow(1 - t, 3) * _controlPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * _controlPoints[1].position + 3 * (1 - t) * Mathf.Pow(t, 2) * _controlPoints[2].position + Mathf.Pow(t, 3) * _controlPoints[3].position;
            Gizmos.DrawSphere(_gizmoPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector3(_controlPoints[0].position.x, _controlPoints[0].position.y, _controlPoints[0].position.z), new Vector3(_controlPoints[1].position.x, _controlPoints[1].position.y, _controlPoints[1].position.z));
        Gizmos.DrawLine(new Vector3(_controlPoints[2].position.x, _controlPoints[2].position.y, _controlPoints[2].position.z), new Vector3(_controlPoints[3].position.x, _controlPoints[3].position.y, _controlPoints[3].position.z));


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
