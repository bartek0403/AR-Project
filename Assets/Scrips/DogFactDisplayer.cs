using UnityEngine;
using BWG.Network;
using BWG.UI;

namespace BWG
{
    public class DogFactDisplayer : IFactDisplayer
    {
        private DogFactsProvider _provider;

        public DogFactDisplayer()
        {
            _provider = new DogFactsProvider();
        }

        public async void DisplayFact()
        {
            var task = await _provider.GetDogFactUnity();
            var presenter = GameObject.Instantiate(Resources.Load<FactPresenter>("FactPresenter"));
            presenter.SetText(task.fact);
            presenter.ScheduleLifetime(3f);
        }
    }
}
