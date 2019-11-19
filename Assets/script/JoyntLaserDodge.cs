using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyntLaserDodge : MonoBehaviour
{
    [SerializeField] Transform stepPos1;
    [SerializeField] Transform nextPos1;
    [SerializeField] Transform stepPos2;
    [SerializeField] Transform nextPos2;
    [SerializeField] Transform sidePos;
    [SerializeField] Transform upDownPos;
    [SerializeField] Transform laser1;
    [SerializeField] Transform laser2;
    private Vector3 vel1;
    private Vector3 vec1;
    private Vector3 vel2;
    private Vector3 vec2;

    private int index1=0;
    private int index2=0;
    private float speed = 2;
    public int pattern;
    public float rot;
    // Start is called before the first frame update
    void Start()
    {
        nextPos1 = upDownPos.GetChild(index1);
        nextPos2 = sidePos.GetChild(index2);
    }

    // Update is called once per frame
    void Update()
    {
        DecidePattern();

    }

    private void DecidePattern()
    {

        switch (pattern)
        {
            case 0:
                rot = 1;
                NoMoveRotation();
                break;
            case 1:
                rot = 1;
                MoveRotation();
                break;
            case 2:
                MoveOnry();
                break;
            default:
                NoMoveRotation();
                break;
        }
    }

    private void NoMoveRotation()
    {
        laser1.Rotate(Vector3.up, rot);
        laser2.Rotate(Vector3.up, rot);
    }

    private void MoveRotation()
    {
        vec1 = nextPos1.position - transform.position;
        transform.position += vec1 * speed * Time.deltaTime;
        if (Mathf.Abs(vec1.magnitude) < 1f)
        {
            index1++;
            if (index1 > 1)
            {
                index1 = 0;
            }
            nextPos1 = upDownPos.GetChild(index1);
        }

        laser1.Rotate(Vector3.up, rot);
        laser2.Rotate(Vector3.up, rot);
    }

    private void MoveOnry()
    {

    }
}
