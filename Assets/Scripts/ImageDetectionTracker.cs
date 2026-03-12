using UnityEngine;
using TMPro;

namespace UnityEngine.XR.ARFoundation
{

    public class ImageDetectionTracker : MonoBehaviour
    {
        [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;
        [SerializeField]
        Transform waterfallColliderTransform;
        [SerializeField]
        Transform mushroomColliderTransform;
        [SerializeField]
        Transform crystalColliderTransform;
        [SerializeField]
        Transform flowerColliderTransform;
        [SerializeField]
        TMP_Text guiText;
        [SerializeField]
        float waterfallWidth;
        [SerializeField]
        float flowerWidth;
        [SerializeField]
        float crystalWidth;
        [SerializeField]
        float mushroomWidth;
        [SerializeField]
        GameStateMachine gameStateMachine;



        void OnEnable() => m_TrackedImageManager.trackablesChanged.AddListener(OnChanged);

        void OnDisable() => m_TrackedImageManager.trackablesChanged.RemoveListener(OnChanged);

        void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {
                if (newImage.size.x.Equals(waterfallWidth))
                {
                    waterfallColliderTransform.SetParent(newImage.transform);
                    waterfallColliderTransform.position = newImage.transform.position;
                    gameStateMachine.detectWaterfall();
                } else if (newImage.size.x.Equals(mushroomWidth))
                {
                    mushroomColliderTransform.SetParent(newImage.transform);
                    mushroomColliderTransform.position = newImage.transform.position;
                } else if (newImage.size.x.Equals(crystalWidth))
                {
                    crystalColliderTransform.SetParent(newImage.transform);
                    crystalColliderTransform.position = newImage.transform.position;
                    gameStateMachine.detectCrystal();
                } else if (newImage.size.x.Equals(flowerWidth))
                {
                    flowerColliderTransform.SetParent(newImage.transform);
                    flowerColliderTransform.position = newImage.transform.position;
                }
            }

            foreach (var updatedImage in eventArgs.updated)
            {
                // Handle updated event
            }

            foreach (var removedImage in eventArgs.removed)
            {
                // Handle removed event
            }
        }
    }
}
