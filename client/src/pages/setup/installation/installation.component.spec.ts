import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpErrorResponse, HttpResponseBase } from '@angular/common/http';
import { ComponentFixtureAutoDetect } from '@angular/core/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { of } from 'rxjs';

import { MockNotificationService } from '../../../service/notification.service.spec';
import { NotificationService } from '../../../service/notification.service';
import { MockInstallationService } from './installation.service.spec';
import { InstallationComponent } from './installation.component';
import { InstallationService } from './installation.service';
import { MockRouter } from '../../../mock/router.mock';

let router              = new MockRouter();
let installationService = new MockInstallationService();
let notificationService = new MockNotificationService();

let headline            : HTMLElement;
let component           : InstallationComponent;
let fixture             : ComponentFixture<InstallationComponent>;

describe('InstallationComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports : [ InstallationComponent, BrowserAnimationsModule ],
      providers : [
        { provide: Router,                        useValue: router                },
        { provide: NotificationService,           useValue: notificationService   },
        { provide: InstallationService,           useValue: installationService   },
        { provide: ComponentFixtureAutoDetect,    useValue: true                  }
      ]
    }).compileComponents();

    fixture             = TestBed.createComponent(InstallationComponent);
    headline            = fixture.nativeElement.querySelector('h1');
    component           = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have the proper component heading', () => {
    expect(headline.textContent).toContain('Installation');
  });

  it('should register a new installation successfully', () => {
    const stubHttpResponse = of({ status: 200 });

    installationService.add.and.returnValue(stubHttpResponse);

    installationService.add({}).subscribe({
      next: (res : HttpResponseBase) => {
        expect(res.status).toEqual(200);
      }
    });

    expect(installationService.add).toHaveBeenCalled();
  });

  it('should register a new installation failed', () => {
    const stubHttpResponse = of({ status: 400 });

    installationService.add.and.returnValue(stubHttpResponse);

    installationService.add({}).subscribe({
      error: (err : HttpErrorResponse) => {
        expect(err.status).toEqual(400);
      }
    });

    expect(installationService.add).toHaveBeenCalled();
  });

  it('should have an invalid form when fields are empty', () => {
    expect(component.formGroup.valid).toBeFalse();
  });

  it('should validate the form when all fields are filled', () => {
    component.formGroup.controls['name'].setValue('Test Name');
    component.formGroup.controls['logotype'].setValue('test.png');
    expect(component.formGroup.valid).toBeTrue();
  });

  it('should submit form when it is valid', async () => {
    spyOn(component, 'onSubmit');

    component.formGroup.controls['name'].setValue('Test');
    component.formGroup.controls['logotype'].setValue('test.png');
    
    await fixture.whenStable();

    const button = fixture.debugElement.query(By.css('button[mat-button]'));

    button.nativeElement.click();

    expect(component.onSubmit).toHaveBeenCalled();
  });
});