import { ComponentFixture, ComponentFixtureAutoDetect, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MockNotificationService } from '../../../service/notification.service.spec';
import { NotificationService } from '../../../service/notification.service';
import { AccessItemComponent } from './access-item.component';

let notificationService = new MockNotificationService();
const stub              = { title: 'Role', password: 'p@ssW0rd' };

let pass                : HTMLElement;
let headline            : HTMLHeadingElement;
let component           : AccessItemComponent;
let fixture             : ComponentFixture<AccessItemComponent>;

describe('AccessItemComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports   : [AccessItemComponent, BrowserAnimationsModule],
      providers : [
        { provide: NotificationService,           useValue: notificationService   },
        { provide: ComponentFixtureAutoDetect,    useValue: true                  }
      ]
    }).compileComponents();

    fixture     = TestBed.createComponent(AccessItemComponent);    
    headline    = fixture.nativeElement.querySelector('h2');
    pass        = fixture.nativeElement.querySelector('em');    
    component   = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should data input changed reflect the html rendered', async () => {
    fixture.componentRef.setInput('title', stub.title);
    fixture.componentRef.setInput('password', stub.password);

    await fixture.whenStable();

    expect(headline.textContent).toContain(stub.title);
    expect(pass.textContent).toContain(stub.password);
  });
});
