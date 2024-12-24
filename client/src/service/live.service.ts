import { RoomEntity } from '../shared/entity/room.entity';
import { Injectable, signal } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({ providedIn: 'root' })
export class LiveService {

  readonly connection : signalR.HubConnection;

  roomAdded = signal<RoomEntity | null>(null);
  
  constructor() {
    this.connection = new signalR
      .HubConnectionBuilder()
        .withUrl('/live')
        .build();
  }

  initialize() : Promise<void>{
    return this.connection.start();
  }

  disconnect() : Promise<void>{
    return this.connection.stop();
  }

  get status() : signalR.HubConnectionState{
    return this.connection.state;
  }
}