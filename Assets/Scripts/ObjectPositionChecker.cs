using UnityEngine;

public class ObjectPositionChecker : MonoBehaviour
{
    public int correctObjectNumber; // N�mero correto do objeto que deve estar nessa posi��o
    private bool objectInPlace = false;
    public Animator doorOpen;
    public GameObject ma�aneta;
    public GameObject  ordemCorreta;
    public GameObject ordemIncorreta;
    public AudioSource ordemOutcorreta;
    public AudioSource ordemOutIncorreta;
    private void Start()
    {
        if (doorOpen == null)
        {
            doorOpen = GetComponent<Animator>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        ObjectNumber objectNumber = other.GetComponent<ObjectNumber>();
        if (objectNumber != null && objectNumber.number == correctObjectNumber)
        {
            objectInPlace = true;
            
            CheckAllPositions();
        }
    }

    void OnTriggerExit(Collider other)
    {
        ObjectNumber objectNumber = other.GetComponent<ObjectNumber>();
        if (objectNumber != null && objectNumber.number == correctObjectNumber)
        {
            objectInPlace = false;
            ordemIncorreta.SetActive(true);
            ordemOutIncorreta.Play();
        }
    }

    public bool IsObjectInPlace()
    {
        return objectInPlace;
    }

    void CheckAllPositions()
    {
        ObjectPositionChecker[] allCheckers = FindObjectsOfType<ObjectPositionChecker>();
        foreach (ObjectPositionChecker checker in allCheckers)
        {
            if (!checker.IsObjectInPlace())
            {
                return;
            }
        }

        OpenDoor();
    }

    void OpenDoor()
    {
        Debug.Log("All objects are in place. Open the door!");
        ordemCorreta.SetActive(true);
        ordemOutcorreta.Play(); 
        // C�digo para abrir a porta
        // DoorController.Instance.OpenDoor();
        ma�aneta.SetActive(true);
    }
}