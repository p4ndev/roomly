import { MenuItemComponent } from '../menu-item/menu-item.component';
import { MenuItemBase } from '../menu-item/menu-item-base.component';
import { Component } from '@angular/core';

@Component({
  selector    : 'app-viewer-menu',
  imports     : [MenuItemComponent],
  template    : `
    <app-menu-item [model]="menuItemModel.Dashboard"    [delay]="1.2"  />
    <app-menu-item [model]="menuItemModel.LogOut"       [delay]="1"    />
  `
})
export class ViewerMenuComponent extends MenuItemBase {}