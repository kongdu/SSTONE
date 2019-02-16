using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject beamStart;

    public GameObject beamEnd;
    public GameObject beam;
    public LineRenderer line;

    [Header("Adjustable Variables")]
    public float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned

    public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam
    public float textureLengthScale = 3; //Length of the beam texture

    private void Awake()
    {
        beamStart = Instantiate(beamStart, new Vector3(0, 0, 0), Quaternion.identity, transform) as GameObject;
        beamEnd = Instantiate(beamEnd, new Vector3(0, 0, 10), Quaternion.identity, transform) as GameObject;
        beam = Instantiate(beam, new Vector3(0, 0, 0), Quaternion.identity, transform) as GameObject;
        line = beam.GetComponent<LineRenderer>();
    }

    private void Start()
    {
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Vector3 tdir = hit.point - transform.position;
            ShootBeamInDir(transform.position, tdir);
        }*/
    }

    private void Update()
    {
        ShootBeamInDir(transform.position, beamEnd.gameObject.transform.position);
    }

    private void ShootBeamInDir(Vector3 start, Vector3 dir)
    {
        line.positionCount = 2;
        line.SetPosition(0, start);
        beamStart.transform.position = start;

        Vector3 end = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(start, dir, out hit))
            end = hit.point - (dir.normalized * beamEndOffset);
        else
            end = transform.position + (dir * 10);

        beamEnd.transform.position = end;
        line.SetPosition(1, end);

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);

        float distance = Vector3.Distance(start, end);
        line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
        line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0); //빔 이동
    }
}