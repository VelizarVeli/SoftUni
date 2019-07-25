class Hotel {
    constructor(name, capacity) {
      this.name = name;
      this.capacity = capacity;
      this.bookings = [];
      this.currentBookingNumber = 1;
      this.rooms = {
        single: Math.floor(this.capacity / 2),
        double: Math.floor(this.capacity * 0.3),
        maisonette: Math.floor(this.capacity * 0.2),
      };
    }
   
    get roomsPricing() {
      return {
        single: 50,
        double: 90,
        maisonette: 135,
      };
    }
   
    get servicesPricing() {
      return {
        food: 10,
        drink: 15,
        housekeeping: 25,
      };
    }
   
    rentARoom(name, type, nights) {
      if (this.rooms[type] <= 0) {
        let str = `No ${type} rooms available!`;
   
        Object.keys(this.rooms).forEach(room => {
          if (room !== type && this.rooms[room] > 0) {
            str += ` Available ${room} rooms: ${this.rooms[room]}.`;
          }
        });
   
        return str;
      }
   
      this.bookings.push({
        name,
        type,
        nights,
        number: this.currentBookingNumber,
      });
   
      this.currentBookingNumber++;
      this.rooms[type]--;
   
      return `Enjoy your time here Mr./Mrs. ${name}. Your booking is ${this.currentBookingNumber - 1}.`;
    }
   
    roomService(number, type) {
      const providedServices = this.servicesPricing;
      let client = null;
   
      for (const booking of this.bookings) {
        if (booking.number === number) {
          client = booking;
          break;
        }
      }
   
      if (client === null) {
        return `The booking ${number} is invalid.`;
      }
   
      if (providedServices[type] === undefined) {
        return `We do not offer ${type} service.`;
      }
   
      if (client.services === undefined) {
        client.services = [];
      }
   
      client.services.push(type);
      return `Mr./Mrs. ${client.name}, Your order for ${type} service has been successful.`;
    }
   
    checkOut(number) {
      const client = this.bookings.filter(b => b.number === number)[0];
   
      if (!client) {
        return `The booking ${number} is invalid.`;
      }
   
      const totalMoney = this.roomsPricing[client.type] * client.nights;
      let totalServiceMoney;
      if (client.services !== undefined) {
        totalServiceMoney = client.services.reduce((acc, curr) => {
          return acc += this.servicesPricing[curr];
        }, 0);
      }
   
      this.rooms[client.type]++;
      this.currentBookingNumber--;
      this.bookings = this.bookings.filter(b => b.number !== number);
   
      if (client.services === undefined) {
        return `We hope you enjoyed your time here, Mr./Mrs. ${client.name}. The total amount of money you have to pay is ${totalMoney} BGN.`;
      }
   
      return `We hope you enjoyed your time here, Mr./Mrs. ${client.name}. The total amount of money you have to pay is ${totalMoney + totalServiceMoney} BGN. You have used additional room services, costing ${totalServiceMoney} BGN.`;
    }
   
    report() {
      let str = this.name.toUpperCase() + ' DATABASE:\n';
      str += '-'.repeat(20) + '\n';
   
      if (this.bookings.length === 0) {
        str += 'There are currently no bookings.';
        return str;
      }
   
      this.bookings.forEach((client, i) => {
        str += `bookingNumber - ${client.number}\n`;
        str += `clientName - ${client.name}\n`;
        str += `roomType - ${client.type}\n`;
        str += `nights - ${client.nights}\n`;
   
        if (client.services !== undefined) {
          str += `services: ${client.services.join(', ')}\n`;
        }
        if (i !== this.bookings.length - 1) {
          str += '-'.repeat(10) + '\n';
        }
      });
   
      return str.trim();
    }
  }