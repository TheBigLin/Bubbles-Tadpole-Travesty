using UnityEngine;
using Yarn.Unity;

public class PlayerInteraction : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private Interactable currentInteractable;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();


        dialogueRunner.onDialogueStart.AddListener(DisableMovement);
        dialogueRunner.onDialogueComplete.AddListener(EnableMovement);
    }

    private void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueRunner.IsDialogueRunning)
            {
                dialogueRunner.StartDialogue(currentInteractable.dialogueNode);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Interactable interactable))
        {
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentInteractable?.gameObject)
        {
            currentInteractable = null;
        }
    }

    private void DisableMovement()
    {
        playerMovement.canMove = false;
    }

    public void EnableMovement()
    {
        playerMovement.canMove = true;
    }
}