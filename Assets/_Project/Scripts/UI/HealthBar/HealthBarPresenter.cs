using System;
using Zenject;
using BattleArena.Characters;

namespace BattleArena.UI.HealthBar
{
    public class HealthBarPresenter : IInitializable, IDisposable
    {
        private readonly IHealthBarModel _model;
        private readonly IHealthBarView _view;
        private readonly Character _character;

        private bool _maxHealthInitialized;

        public HealthBarPresenter(IHealthBarModel model, IHealthBarView view, Character character)
        {
            _model = model;
            _view = view;
            _character = character;
        }

        public void Initialize()
        {
            _character.OnHealthChanged += ChangeHealth;
            _model.OnHealthChanged += _view.UpdateCurrentHealthView;
            _model.OnMaxHealthChanged += _view.SetMaxHealthView;
        }

        public void ChangeHealth(float currentHealth, float maxHealth)
        {
            _model.ChangeHealth(currentHealth);

            if (_maxHealthInitialized == false)
            {
                _maxHealthInitialized = true;
                SetMaxHealth(maxHealth);
            }
        }

        public void Dispose()
        {
            _character.OnHealthChanged -= ChangeHealth;
            _model.OnHealthChanged -= _view.UpdateCurrentHealthView;
            _model.OnMaxHealthChanged -= _view.SetMaxHealthView;
        }

        private void SetMaxHealth(float maxHealth) => _model.SetMaxHealth(maxHealth);
    }
}