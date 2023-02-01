using UnityEngine;

namespace Tanks.Infrastructure
{
    public static class InputManager
    {
        #region Consts

        private const string HORIZONTAL_AXIS_NAME = "Horizontal";    
        private const string VERTICAL_AXIS_NAME = "Vertical";
        private const KeyCode FIRE_REQUEST_BUTTON = KeyCode.Space;
        private const KeyCode MOVE_RIGHT_REQUEST_BUTTON = KeyCode.RightControl;
        private const KeyCode MOVE_LEFT_REQUEST_BUTTON = KeyCode.LeftControl;
        
        #endregion
        
        #region Methods

        public static float GetRotationInput()
        {
            return Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
        }

        public static float GetMovementInput()
        {
            return Input.GetAxisRaw(VERTICAL_AXIS_NAME);
        }

        public static bool IsFireRequested()
        {
            return Input.GetKeyDown(FIRE_REQUEST_BUTTON);
        }

        public static bool IsSelectRightRequested()
        {
            return Input.GetKeyDown(MOVE_RIGHT_REQUEST_BUTTON);
        }

        public static bool IsSelectLeftRequested()
        {
            return Input.GetKeyDown(MOVE_LEFT_REQUEST_BUTTON);
        }

        #endregion
    }
}