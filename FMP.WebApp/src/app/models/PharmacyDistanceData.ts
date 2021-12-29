import { Coordinate } from "./Coordinate";
import { Pharmacy } from "./Pharmacy";

export interface PharmacyDistanceData {
    pharmacy: Pharmacy;

    origin: Coordinate;

    distanceFromOrigin: number;
}