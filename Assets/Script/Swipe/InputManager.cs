using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch; 
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion

    private Swipe swipe;
    private Camera mainCamera;
    private void Awake()
    {
        swipe = new Swipe();
        mainCamera = Camera.main;
    }
    void Start()
    {
        swipe.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        swipe.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }
    private void OnEnable()
    {
        swipe.Enable();
    }
    private void OnDisable()
    {
        swipe.Disable();
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera, swipe.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera, swipe.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }
    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, swipe.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

}
