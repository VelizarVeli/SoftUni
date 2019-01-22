using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.passengers = new List<IPassenger>();
            this.baggageCompartment = new List<IBag>();
        }

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public int Seats { get; }
        public int BaggageCompartments { get; }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var baggage = this.baggageCompartment.Where(x => x.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return baggage;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}
