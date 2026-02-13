using UnityEngine;

public class Snapping : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        var snapPoint = collider.GetComponent<SnapPoint>();
        if (collider.attachedRigidbody &&
            snapPoint &&
            !snapPoint.connectedObject)
        {
            var newJoint = gameObject.AddComponent<CharacterJoint>();
            newJoint.connectedBody = collider.attachedRigidbody;
            newJoint.connectedAnchor = newJoint.connectedBody.transform.InverseTransformPoint(collider.transform.position);
            newJoint.anchor = new Vector3(0, 0, 0.5f);
            newJoint.autoConfigureConnectedAnchor = false;

            snapPoint.connectedObject = gameObject;
        }
    }
}
