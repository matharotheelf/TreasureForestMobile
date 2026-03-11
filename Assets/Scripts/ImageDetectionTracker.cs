using UnityEngine;

namespace UnityEngine.XR.ARFoundation
{

    public class ImageDetectionTracker : MonoBehaviour
    {
        [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;
        [SerializeField]
        Transform markerObject;

        void OnEnable() => m_TrackedImageManager.trackablesChanged.AddListener(OnChanged);

        void OnDisable() => m_TrackedImageManager.trackablesChanged.RemoveListener(OnChanged);

        void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {
                markerObject.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                markerObject.SetParent(newImage.transform);
                markerObject.position = newImage.transform.position;
                // Handle added event
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
