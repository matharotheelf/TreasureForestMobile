using UnityEngine;
using TMPro;

public class locationCollisionDetector : MonoBehaviour
{
    [SerializeField]
    GameObject flowerColliderObject;

    [SerializeField]
    GameObject mushroomColliderObject;

    [SerializeField]
    TMP_Text guiText;

    [SerializeField]
    int location;

    [SerializeField]
    GameStateMachine gameStateMachine;

    [SerializeField]
    Material selectedMaterial;

    [SerializeField]
    Material deselectedMaterial;

    void OnTriggerEnter(Collider collider)
    {
        if (GameObject.ReferenceEquals(collider.gameObject, flowerColliderObject))
        {
            gameObject.GetComponent<Renderer>().material = selectedMaterial;
            if (location == 0)
            {
                gameStateMachine.selectCrystal("flower");
            }
            else
            {
                gameStateMachine.selectWaterfall("flower");
            }

        }
        else if (GameObject.ReferenceEquals(collider.gameObject, mushroomColliderObject))
        {
            gameObject.GetComponent<Renderer>().material = selectedMaterial;
            if (location == 0)
            {
                gameStateMachine.selectCrystal("mushroom");
            }
            else
            {
                gameStateMachine.selectWaterfall("mushroom");
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (GameObject.ReferenceEquals(collider.gameObject, flowerColliderObject))
        {
            gameObject.GetComponent<Renderer>().material = deselectedMaterial;
            if (location == 0)
            {
                gameStateMachine.deselectCrystal("flower");
            }
            else
            {
                gameStateMachine.deselectWaterfall("flower");
            }

        }
        else if (GameObject.ReferenceEquals(collider.gameObject, mushroomColliderObject))
        {
            gameObject.GetComponent<Renderer>().material = deselectedMaterial;
            if (location == 0)
            {
                gameStateMachine.deselectCrystal("mushroom");
            }
            else
            {
                gameStateMachine.deselectWaterfall("mushroom");
            }
        }
    }
}
