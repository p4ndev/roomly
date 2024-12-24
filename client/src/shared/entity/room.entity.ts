import { ReservationEntity } from "./reservation.entity";

export interface RoomEntity{
    id              : number,
    capacity        : number,
    name            : string,
    description     : string,
    reservations    : Array<ReservationEntity>
}