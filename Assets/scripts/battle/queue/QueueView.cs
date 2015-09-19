using ui;
using UnityEngine;
using UnityEngine.UI;

namespace battle.queue
{
    class QueueView : InteractableBase
    {
        public AbilityProgress abilityProgress;

        [SerializeField]
        private Image progressImg;
        [SerializeField]
        private GameObject view;

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
            this.abilityProgress = progress;
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
            Messenger<int>.Broadcast(AbilityQueue.TRY_CANCEL_ABILITY, id);
        }

    }
}
