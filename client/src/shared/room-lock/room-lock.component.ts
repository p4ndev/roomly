import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatIconModule } from '@angular/material/icon';
import { RoomEntity } from '../entity/room.entity';
import { Component, input } from '@angular/core';

@Component({
  selector    : 'app-room-lock',
  styleUrl    : './room-lock.component.scss',
  templateUrl : './room-lock.component.html',
  imports     : [ MatIconModule, MatProgressBarModule ]
})
export class RoomLockComponent {
  room = input.required<RoomEntity>();
}
