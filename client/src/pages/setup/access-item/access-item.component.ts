import { NotificationService } from '../../../service/notification.service';
import { Component, inject, input } from '@angular/core';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector    : 'app-access-item',
  styleUrl    : './access-item.component.scss',
  templateUrl : './access-item.component.html',
  imports     : [ MatIcon ],
})
export class AccessItemComponent {

  title                 = input<string>();
  password              = input<string>();
  notificationService   = inject(NotificationService);

  async onCopyToClipboard() : Promise<void>{
    if(!this.password())
      return;

    await navigator.clipboard.writeText(this.password()!);
    this.notificationService.notify('Content copied successfully.');
  }
}
