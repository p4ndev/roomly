import { ComponentFixture, ComponentFixtureAutoDetect, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Router } from '@angular/router';

import { AccessComponent } from './access.component';
import { MockRouter } from '../../../mock/router.mock';

let router      = new MockRouter();
const stub      = { viewer : '111', coordinator : '222', administrator : '333' };

let component   : AccessComponent;
let fixture     : ComponentFixture<AccessComponent>;

describe('AccessComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccessComponent, BrowserAnimationsModule],
      providers: [
        { provide: Router,                          useValue: router   },
        { provide: ComponentFixtureAutoDetect,      useValue: true     }
      ]
    }).compileComponents();
    
    fixture = TestBed.createComponent(AccessComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
