import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentFixtureAutoDetect } from '@angular/core/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { of, throwError } from 'rxjs';

import { MockNotificationService } from '../../../service/notification.service.spec';
import { NotificationService } from '../../../service/notification.service';
import { MockStartupService } from './startup.service.spec';
import { ActionsEnum } from '../../../enum/actions.enum';
import { StartupComponent } from './startup.component';
import { MockRouter } from '../../../mock/router.mock';
import { StartupService } from './startup.service';
import { i18n } from '../../../data/i18n.const';

let router              = new MockRouter();
let startupService      = new MockStartupService();
let notificationService = new MockNotificationService();

let component           : StartupComponent;
let fixture             : ComponentFixture<StartupComponent>;

describe('StartupComponent', () => {  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports   : [StartupComponent, BrowserAnimationsModule],
      providers : [
        { provide: Router,                          useValue: router                },
        { provide: StartupService,                  useValue: startupService        },
        { provide: NotificationService,             useValue: notificationService   },
        { provide: ComponentFixtureAutoDetect,      useValue: true                  }
      ]
    }).compileComponents();

    fixture             = TestBed.createComponent(StartupComponent);
    component           = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should notify loading configuration on init', () => {
    component.ngOnInit();
    
    expect(notificationService.notify)
      .toHaveBeenCalledWith(i18n.StartUp.LoadingConfiguration);
  });

  it('should navigate to auth on configuration found on api call', () => {
    startupService.load.and.returnValue(of(null));
    
    component.ngOnInit();

    expect(notificationService.close)
      .toHaveBeenCalled();
    
      expect(router.navigate)
      .toHaveBeenCalledWith(['setup', ActionsEnum.Auth]);
  });

  it('should notify missing configuration and navigate to install', () => {
    startupService.load.and.returnValue(throwError(() => new Error('Error loading configuration')));
    
    component.ngOnInit();
    
    expect(notificationService.notify)
      .toHaveBeenCalledWith(i18n.StartUp.MissingConfiguration);
    
    expect(router.navigate)
      .toHaveBeenCalledWith(['setup', ActionsEnum.Install]);
  });
});