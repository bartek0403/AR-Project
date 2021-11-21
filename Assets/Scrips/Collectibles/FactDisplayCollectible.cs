using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWG
{
    public class FactDisplayCollectible : SimpleCollectible
    {

        private IFactDisplayer _factDisplayer;

        public void SetDisplayer(IFactDisplayer displayer)
        {
            _factDisplayer = displayer;
        }

        public override void Collect()
        {
            if (_factDisplayer != null)
            {
                _factDisplayer.DisplayFact();
            }
            base.Collect();
        }
    }
}
