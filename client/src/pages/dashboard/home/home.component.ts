import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {Component, signal} from '@angular/core';

@Component({
  selector    : 'app-home',
  styleUrl    : './home.component.scss',
  templateUrl : './home.component.html',
  imports     : [ MatButtonModule, MatIconModule, MatTooltipModule, MatProgressBarModule ]
})
export class HomeComponent {
  
  isConnected = signal(false);

}