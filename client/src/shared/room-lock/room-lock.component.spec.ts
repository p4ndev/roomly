import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomLockComponent } from './room-lock.component';

describe('RoomLockComponent', () => {
  let component: RoomLockComponent;
  let fixture: ComponentFixture<RoomLockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RoomLockComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoomLockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
