using System;
using PlayerInput;
using StaticData;
using UnityEngine;

namespace Weapon
{
    public abstract class WeaponLogicBase
    {
        private UserInputManager _inputManager;
        protected LayerMask _backGround;
        protected WeaponDataBase _weaponDataBase;
        protected WeaponConfig _weaponConfig;
        private bool _isActive;

        protected event Action<RaycastHit> RayCreatedOnMouseButtonPress;
        protected event Action<RaycastHit> RayCreatedOnMouseButtonHold;

        protected WeaponLogicBase(UserInputManager inputManager, LayerMask backGround, WeaponDataBase weaponDataBase, WeaponConfig weaponConfig)
        {
            _inputManager = inputManager;
            _backGround = backGround;
            _weaponDataBase = weaponDataBase;
            _weaponConfig = weaponConfig;
        }

        public virtual void Initialize()
        {
            _inputManager.ButtonMousePressed += OnMouseButtonPress;
            _inputManager.ButtonMouseHold += OnMouseButtonHold;
        }

        private void OnMouseButtonPress()
        {
            var hit = GetHit();

            if (hit.collider != null)
            {
                RayCreatedOnMouseButtonPress?.Invoke(hit);
            }
        }
        
        private void OnMouseButtonHold()
        {
            var hit = GetHit();

            if (hit.collider != null)
            {
                RayCreatedOnMouseButtonHold?.Invoke(hit);
            }
        }

        private RaycastHit GetHit()
        {
            var ray = _inputManager.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, _backGround);

            return hit;
        }
    }
}
