import { MenuItemBase } from '../menu-item/menu-item-base.component';
import { MenuItemComponent } from '../menu-item/menu-item.component';
import { Component } from '@angular/core';

@Component({
  selector    : 'app-administrator-menu',
  imports     : [MenuItemComponent],
  template    : `
    <app-menu-item [model]="menuItemModel.Dashboard"    [delay]="1.6"  />
    <app-menu-item [model]="menuItemModel.Schedule"     [delay]="1.4"  />
    <app-menu-item [model]="menuItemModel.Management"   [delay]="1.2"  />
    <app-menu-item [model]="menuItemModel.LogOut"       [delay]="1"    />
  `
})
export class AdministratorMenuComponent extends MenuItemBase {}