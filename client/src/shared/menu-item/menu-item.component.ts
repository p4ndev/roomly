import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { Component, input } from '@angular/core';
import { NgStyle } from '@angular/common';
import { MenuItemDto } from './menu-item.dto';

@Component({
  selector        : 'app-menu-item',
  styleUrl        : './menu-item.component.scss',
  templateUrl     : './menu-item.component.html',
  imports         : [ MatIconModule, RouterLink, RouterLinkActive, NgStyle ]
})
export class MenuItemComponent {
  delay = input<number>(0);
  model = input<MenuItemDto | null>(null);
}