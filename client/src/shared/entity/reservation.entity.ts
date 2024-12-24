export interface ReservationEntity{
    id          : number,
    roomId      : number,
    startsAt    : Date,
    endsAt      : Date,
    description : string
}