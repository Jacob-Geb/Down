﻿using ui;
using UnityEngine;
using UnityEngine.UI;

namespace battle.queue
{
    class QueueView : InteractableBase
    {

        [SerializeField]
        private Image progressImg;
        [SerializeField]
        private GameObject view;
        [SerializeField]
        private Image icon;

        public AbilityProgress abilityProgress { get; protected set; }
        private int id;

        public void init(int id)
        {
            this.id = id;
            hideView();
        }

        void OnEnable()
        {
            this.shortPress += onShortPress;
        }

        void OnDisable()
        {
            this.shortPress -= onShortPress;
        }

        private void Update()
        {
            if ( abilityProgress != null)
                progressImg.fillAmount = abilityProgress.progress;
        }

        public void init(AbilityProgress progress)
        {
            abilityProgress = progress;
            icon.sprite = Resources.Load<Sprite>(abilityProgress.command.iconPath); 
            showView();
        }

        public void hide()
        {
            hideView();
        }

        private void showView( )
        {
            view.gameObject.SetActive(true);
  
        }
        private void hideView()
        {
            view.gameObject.SetActive(false);
        }

        private void onShortPress()
        {
            // TODO: if (player's)
            Messenger<int>.Broadcast(BattleUIEvent.PLAYER_QUEUE_ITEM_PRESS, id);
        }

    }
}
