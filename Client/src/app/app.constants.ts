import { Airport } from "./enums/airport.enum";

export const keys = Object.keys(Airport).map(k => Airport[k as any])
export const baseUrl = 'https://localhost:5001/api'