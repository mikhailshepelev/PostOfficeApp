import { Bag } from "./bag";

export class Shipment {
    id: number;
    number: string;
    airport: string;
    flightNumber: string;
    flightDate: Date;
    isFinalized: boolean;  
    bags: Bag[]; 
}
