using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInteractable _interactable;
    public IInteractable Interactable
    {
        get => _interactable;
        set
        {
            if (_interactable != value)
            {
                _interactable?.OnInteractStop();
                _interactable = value;
                _interactable?.OnInteractStart();
            }
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit)
            && raycastHit.transform.TryGetComponent(out IInteractable interactable))
        {
            Interactable = interactable;
        }
        else
        {
            Interactable = null;
        }
    }
}
