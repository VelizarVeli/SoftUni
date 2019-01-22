using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using System;
	using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void SetControllerShouldReturnFailMessage()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

	        ISet set = new Short("Set1");
            stage.AddSet(set);

	        string expectedResult = "1. Set1:\r\n-- Did not perform";
	        string actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
	    }

        [Test]
        public void SetControllerShouldReturnSuccessMessage()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);


            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Pesho", 18);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer); 

            ISong song = new Song("Zaz - Ututudu", new TimeSpan(0, 2, 32));
            set.AddSong(song);
            stage.AddSet(set);

            string expectedResult = "1. Set1:\r\n-- 1. Zaz - Ututudu (02:32)\r\n-- Set Successful";
            string actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSetShouldDecreaseInstrumentWear()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);


            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Pesho", 18);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            ISong song = new Song("Zaz - Ututudu", new TimeSpan(0, 2, 32));
            set.AddSong(song);

            stage.AddSet(set);

            double instrumentWearBeforePerforming = instrument.Wear;

            setController.PerformSets();

            double instrumentWearAfterPerforming = instrument.Wear;

            Assert.That(instrumentWearAfterPerforming, Is.Not.EqualTo(instrumentWearBeforePerforming));
        }
    }
}