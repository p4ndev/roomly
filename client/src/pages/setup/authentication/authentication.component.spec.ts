import { ComponentFixture, ComponentFixtureAutoDetect, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { By } from '@angular/platform-browser';
import { Router } from '@angular/router';

import { MockNotificationService } from '../../../service/notification.service.spec';
import { NotificationService } from '../../../service/notification.service';
import { MockSessionService } from '../../../service/session.service.spec';
import { MockAuthenticationService } from './authentication.service.spec';
import { AuthenticationComponent } from './authentication.component';
import { SessionService } from '../../../service/session.service';
import { AuthenticationService } from './authentication.service';
import { MockRouter } from '../../../mock/router.mock';

let router                = new MockRouter();
let sessionService        = new MockSessionService();
let notificationService   = new MockNotificationService();
let authenticationService = new MockAuthenticationService();

let headline              : HTMLElement;
let component             : AuthenticationComponent;
let fixture               : ComponentFixture<AuthenticationComponent>;

describe('AuthenticationComponent', () => {  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports   : [AuthenticationComponent, BrowserAnimationsModule],
      providers : [
        { provide: Router,                        useValue: router                },
        { provide: SessionService,                useValue: sessionService        },
        { provide: NotificationService,           useValue: notificationService   },
        { provide: AuthenticationService,         useValue: authenticationService },
        { provide: ComponentFixtureAutoDetect,    useValue: true                  }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(AuthenticationComponent);
    headline = fixture.nativeElement.querySelector('h1');
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have the proper component heading', () => {
    expect(headline.textContent).toContain('Authentication');
  });

  it('should have an invalid form when fields are empty', () => {
    expect(component.formGroup.valid).toBeFalse();
  });

  it('should validate the form with a random password', () => {
    component.formGroup.controls['password'].setValue('45t45yh657');
    expect(component.formGroup.valid).toBeTrue();
  });

  it('should submit form for a valid administrator password', async () => {
    spyOn(component, 'onSubmit');

    component.formGroup.controls['password'].setValue('5S>VaD{7');

    await fixture.whenStable();

    const button = fixture.debugElement.query(By.css('button[mat-button]'));

    button.nativeElement.click();

    expect(component.onSubmit).toHaveBeenCalled();
  });
});
