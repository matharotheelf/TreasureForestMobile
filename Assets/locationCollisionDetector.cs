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

    void OnTriggerEnter(Collider collider)
    {
        if (GameObject.ReferenceEquals(collider.gameObject, flowerColliderObject))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 100);
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
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 100);
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
}
