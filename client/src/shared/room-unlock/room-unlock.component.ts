import {MatBadgeModule} from '@angular/material/badge';
import { RoomEntity } from '../entity/room.entity';
import { Component, input } from '@angular/core';

@Component({
  selector    : 'app-room-unlock',  
  styleUrl    : './room-unlock.component.scss',
  templateUrl : './room-unlock.component.html',
  imports     : [MatBadgeModule]
})
export class RoomUnlockComponent {
  room = input.required<RoomEntity>();
}