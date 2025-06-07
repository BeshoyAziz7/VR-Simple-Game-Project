using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SCRIPTLID : MonoBehaviour
{
    public GameObject chestLid;
    public float openingAngle = 45.0f;
    public float forceMagnitude = 50.0f;
    public float maxLidRotation = 45.0f;
    public float interactionDistance = 1.0f; // Distance for remote activation

    private Rigidbody lidRigidbody;
    private float currentLidRotation = 0.0f;

    private void Start()
    {
        lidRigidbody = chestLid.GetComponent<Rigidbody>();
        if (!lidRigidbody)
        {
            Debug.LogError("Chest lid object must have a Rigidbody component.");
            return;
        }
    }

    public void OpenLid(XRBaseInteractor interactor)
    {
        if (currentLidRotation < maxLidRotation)
        {
            // Check if the interactor (remote) is within the interaction distance
            if (Vector3.Distance(interactor.transform.position, chestLid.transform.position) <= interactionDistance)
            {
                lidRigidbody.AddForceAtPosition(Vector3.up * forceMagnitude, chestLid.transform.position, ForceMode.Impulse);
                currentLidRotation += Time.deltaTime * 50.0f;
            }
            else
            {
                Debug.Log("Remote is too far from the chest.");
            }
        }
    }
}