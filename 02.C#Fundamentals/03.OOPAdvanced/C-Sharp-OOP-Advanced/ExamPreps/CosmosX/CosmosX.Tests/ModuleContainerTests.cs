using System.Collections.Generic;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;

namespace CosmosX.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void PerformTestShouldRemoveOldestModule()
        {
            //IModule modulesByInput = new List(IModule);
            //int removeId = this.modulesByInput[0].Id;
        }


        //private void RemoveOldestModule()
        //{
        //    int removeId = this.modulesByInput[0].Id;

        //    this.modulesByInput.RemoveAt(0);

        //    if (this.energyModules.ContainsKey(removeId))
        //    {
        //        this.energyModules.Remove(removeId);
        //    }

        //    if (this.absorbingModules.ContainsKey(removeId))
        //    {
        //        this.absorbingModules.Remove(removeId);
        //    }
        //}

    }
}

//IStage stage = new Stage();
//ISetController setController = new SetController(stage);


//ISet set = new Short("Set1");
//IPerformer performer = new Performer("Pesho", 18);
//IInstrument instrument = new Guitar();
//performer.AddInstrument(instrument);
//set.AddPerformer(performer);

//ISong song = new Song("Zaz - Ututudu", new TimeSpan(0, 2, 32));
//set.AddSong(song);

//stage.AddSet(set);

//double instrumentWearBeforePerforming = instrument.Wear;

//setController.PerformSets();

//double instrumentWearAfterPerforming = instrument.Wear;

//Assert.That(instrumentWearAfterPerforming, Is.Not.EqualTo(instrumentWearBeforePerforming));
