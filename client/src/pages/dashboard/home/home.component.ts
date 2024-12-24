import { Component, effect, inject, OnDestroy, OnInit, resource, signal } from '@angular/core';
import { RoomUnlockComponent } from '../../../shared/room-unlock/room-unlock.component';
import { RoomLockComponent } from '../../../shared/room-lock/room-lock.component';
import { SessionService } from '../../../service/session.service';
import { RoomEntity } from '../../../shared/entity/room.entity';
import { environment } from '../../../environments/environment';
import { MatTooltipModule } from '@angular/material/tooltip';
import { LiveService } from '../../../service/live.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { HttpStatusCode } from '@angular/common/http';
import { ReservationEntity } from '../../../shared/entity/reservation.entity';

@Component({
  selector    : 'app-home',
  styleUrl    : './home.component.scss',
  templateUrl : './home.component.html',
  imports     : [ MatButtonModule, MatTooltipModule, MatIconModule, RoomUnlockComponent, RoomLockComponent ]
})
export class HomeComponent implements OnInit, OnDestroy {
  
  sessionService = inject(SessionService);
  model = signal<Array<RoomEntity>>([]);
  liveService = inject(LiveService);  

  constructor(){
    effect(() => {
      const source = (this.restfulResponse.value() ?? undefined);
      if(source) this.onMultiResponse(source!);
    });
  }

  ngOnInit(): void {
    this.liveService
      .connection
        .on('RoomAdded', this.onSingleResponse);

    this.liveService
      .initialize()
        .then(() => this.setConnection(true))
        .catch(() => this.setConnection(false));
  }

  ngOnDestroy(): void {
    this.setConnection(false)
    this.liveService.disconnect();
  }

  private restfulResponse = resource({
    loader : async () : Promise<Array<RoomEntity>> => {
      const response = await fetch(
        `${environment.api}/dashboard`,
        {
          headers: {
            "Authorization": `Bearer ${this.sessionService.token()}`,
          }
        }
      );

      if(response.status !== HttpStatusCode.Ok)
        return [];
      
      return ((await response.json()) as Array<RoomEntity>);      
    }
  });

  isLocked = (source : Array<ReservationEntity>) : boolean => {
    const rightNow = new Date();
    let output = false;

    source
      .forEach(e => {
        if(rightNow >= e.startsAt && rightNow <= e.endsAt){
          output = true;
          return;
        }
      });

    return output;
  };

  private onSingleResponse = (res : RoomEntity) => this.model.update(data => [...data!, res]);
  private setConnection = (value : boolean) : void => this.sessionService.isConnected.set(value);
  private onMultiResponse = (res : Array<RoomEntity>) => this.model.update(data => [...data!].concat(res));
}