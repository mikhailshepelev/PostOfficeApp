import { Parcel } from "./parcel";

export class Bag {
    id: number;
    number: string;
    lettersCount: number;
    shipmentId: number;
    discriminator: string;
    weight: number;
    price: number;
    parcelsCount: number;
    parcels: Parcel[];
}
