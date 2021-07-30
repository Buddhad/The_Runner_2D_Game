
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float offset;
    Transform playertransform;
    Transform selfTransform;
    // Start is called before the first frame update
    void Start()
    {
        selfTransform = transform;
        playertransform = GameObject.FindGameObjectWithTag(TagTracker.playertag).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movePosition= new Vector3(playertransform.position.x - offset, selfTransform.position.y, selfTransform.position.z);
        selfTransform.position = Vector3.Lerp(selfTransform.position, movePosition, Time.deltaTime * 5);
    }
}
